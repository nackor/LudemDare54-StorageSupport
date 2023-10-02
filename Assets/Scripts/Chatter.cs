using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chatter : MonoBehaviour
{
    [SerializeField]
    TutorialManager tutorialManager;
    [SerializeField]
    ChatManager ChatManager;

    [SerializeField]
    public ChatRecord Chat;

    [SerializeField]
    public float ChatDelay =1f;

    private float timer = 0;

    bool chatting = false;
    // Start is called before the first frame update
    public void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > ChatDelay && chatting)
        {
            //send message
            timer = 0;
            Chat newChat = Chat.GetNextMessage();
            if (newChat == null)
            {
                return;
            }
            ChatManager.SendChat(newChat.Message);
            if(newChat.Question == true)
            {
                if(tutorialManager!= null)
                {
                    tutorialManager.GotQuestion();
                }
            }
        }
    }

    public void StartChatting(ChatRecord chat)
    {
        if(chat != null)
        {
            Chat = chat;
        }

        chatting = true;
    }

    public void PauseChatting()
    {
        chatting = false;
    }
    public void ResumeChatting()
    {
        chatting = true;
    }

    
}
