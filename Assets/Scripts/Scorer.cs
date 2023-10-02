using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Scorer : MonoBehaviour
{
    public int TotalPassed;
    public int TotalFailed;
    public int TotalDrives;
    public int TotalFilesLeft;


    [SerializeField]
    public TextMeshProUGUI PassedField;
    [SerializeField]
    public TextMeshProUGUI FailedField;
    [SerializeField]
    public TextMeshProUGUI DrivesField;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        gameManager = FindAnyObjectByType<GameManager>();
    }
    private void Update()
    {
        if(gameManager == null)
        {
            gameManager = FindAnyObjectByType<GameManager>();
        }
    }

    public IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1);
        PassedField.text = TotalPassed.ToString();
        FailedField.text = TotalFailed.ToString();
        DrivesField.text = TotalDrives.ToString() + "/9";
    }
}
