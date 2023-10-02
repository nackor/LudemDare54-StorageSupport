using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{

    [SerializeField]
    GameObject FileTransferArea;
    [SerializeField]
    GameObject Drives;
    [SerializeField]
    GameObject StorageManager;
    [SerializeField]
    GameObject Rules;
    [SerializeField]
    GameObject Security;

    [SerializeField]
    ChatRecord Tutorial;
    [SerializeField]
    Chatter chatter;

    bool noAnswer = true;
    bool WaitingForQuestion = false;
    int questionCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        chatter.StartChatting(Tutorial);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitForUser()
    {
        WaitingForQuestion = true;
        chatter.PauseChatting();
        while (noAnswer)
        {
            yield return new WaitForSeconds(1);
        }
        chatter.ResumeChatting();
    }

    public void GotQuestion()
    {
        StartCoroutine(WaitForUser());
    }

    public void Yes()
    {

        if (!WaitingForQuestion) { return; }
        if (questionCount > 0)
        {
            SceneManager.LoadScene("Shift1");
            return;
        }
        questionCount++;
        chatter.ChatDelay = 4f;
        StartCoroutine(DoTutorial());
        noAnswer = false;
        WaitingForQuestion = false;
    }

    IEnumerator DoTutorial()
    {
        yield return new WaitForSeconds(chatter.ChatDelay*3);
        FileTransferArea.SetActive(true);
        yield return new WaitForSeconds(chatter.ChatDelay);
        Drives.SetActive(true);
        yield return new WaitForSeconds(chatter.ChatDelay);
        Security.SetActive(true);
        yield return new WaitForSeconds(chatter.ChatDelay);
        FileTransferArea.SetActive(false);
        Drives.SetActive(false);
        StorageManager.SetActive(true);
        yield return new WaitForSeconds(chatter.ChatDelay);
        Rules.SetActive(true);
        yield return new WaitForSeconds(chatter.ChatDelay * 3);
        FileTransferArea.SetActive(false);
        Drives.SetActive(false);
        Security.SetActive(false);
        StorageManager.SetActive(false);
        Rules.SetActive(false);

    }

    public void No()
    {
        if (!WaitingForQuestion) { return; }
        WaitingForQuestion = false;
        noAnswer = false;
        SceneManager.LoadScene("Shift1");
    }
}
