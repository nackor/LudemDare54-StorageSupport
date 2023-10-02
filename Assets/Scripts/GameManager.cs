using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    public List<Ticket> TicketList = new List<Ticket>();

    bool TicketBeingWorked = false;


    public bool gameStarted = false;

    public AudioSource FailureSound;
    public AudioSource SuccessSound;

    TicketTracker tracker;

    [SerializeField]
    int MinusYears = -25;

    [SerializeField]
    float GameTimer = 180;
    [SerializeField]
    DateTime CurrentDate;
    [SerializeField]
    TextMeshProUGUI Timer;
    [SerializeField]
    TextMeshProUGUI DateField;

    [SerializeField]
    Chatter chatter;
    [SerializeField]
    ChatRecord endShift;
    [SerializeField]
    ChatRecord beginShift;
    [SerializeField]
    ChatRecord YouAreFired;
    [SerializeField]
    GameObject ChatBox;
    FileGenerator fileGen;
    bool shiftEnded = false;
    Canvas canvas;

    [SerializeField]
    int AddDay = 0;

    Scorer scorer;
    // Start is called before the first frame update
    void Start()
    {
       fileGen = GetComponent<FileGenerator>();
       CurrentDate = DateTime.Now.AddYears(MinusYears).AddDays(AddDay);
       tracker = FindObjectOfType<TicketTracker>();
       DateField.text = CurrentDate.ToShortDateString();
       Timer.text = GameTimer.ToString();
       canvas = FindObjectOfType<Canvas>();
       scorer = FindAnyObjectByType<Scorer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            GameTimer -= Time.deltaTime;
            Timer.text = GameTimer.ToString("###.");
        }
        if(GameTimer <= 1)
        {
            gameStarted = false;
            EndShift();
        }
        if (fileGen.FTPDrive != null)
        {
            if (fileGen.FTPDrive.LongCurrent >= fileGen.FTPDrive.LongMax)
            {
                BadGameOver();
            }
        }

    }

    internal void ItemMoved(bool moveSuccess)
    {
        if (moveSuccess)
        {
            tracker.GoodMoves += 1;
            SuccessSound.Play();
        }
        else
        {
            tracker.BadMoves += 1;
            FailureSound.Play();
        }
    }

    internal void UpdateScanTracker()
    {
        tracker.IncrementScanTracker();
    }

    internal DateTime CurrentTime()
    {
        return DateTime.Now.AddYears(MinusYears).AddDays(AddDay);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void BadGameOver()
    {
        gameStarted = false;
        fileGen.FileSendRate = float.MaxValue;
        chatter.StartChatting(YouAreFired);
        ChatBox.GetComponent<RectTransform>().SetAsLastSibling();
    }

    public void NextShift()
    {
        if (shiftEnded)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void EndShift()
    {
        foreach(Transform child in canvas.transform)
        {
            if(child.gameObject.name != "ChatBox" && child.gameObject.name != "TicketTracker" && child.gameObject.name != "Background" && child.gameObject.name != "Restart" && child.gameObject.name != "Taskbar")
            {
                child.gameObject.SetActive(false);
            }
        }
        shiftEnded = true;
        chatter.StartChatting(endShift);
        scorer.TotalFailed += tracker.BadMoves;
        scorer.TotalPassed += tracker.GoodMoves;
        scorer.TotalDrives += tracker.drivesScanned;
    }
}
