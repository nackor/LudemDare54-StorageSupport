using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPinger : MonoBehaviour
{

    [SerializeField]
    int PingInterval = 30;
    [SerializeField]
    Chatter chatter;
    [SerializeField]
    List<ChatRecord> chats;
    float timer = 0f;

    int counter = 0;
    [SerializeField]
    RectTransform ChatBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > PingInterval)
        {
            timer = -3f;
            ChatPing();
        }
    }

    private void ChatPing()
    {
        if(counter <= chats.Count)
        {
            chatter.StartChatting(chats[counter]);
            counter++;
            ChatBox.SetAsLastSibling();
        }
    }
}
