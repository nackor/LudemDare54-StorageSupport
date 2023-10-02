using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class ChatRecord : MonoBehaviour
{

    [SerializeField]
    public TextAsset jsonFile;
    Queue<Chat> chatQueue = new Queue<Chat>();


    public Chat GetNextMessage()
    {
        if(chatQueue.Count > 0)
        {
            return chatQueue.Dequeue();
        }
        return null;
    }
    void Start()
    {
        Chats chats = JsonUtility.FromJson<Chats>(jsonFile.text);

        foreach (Chat chat in chats.chats)
        {
            chatQueue.Enqueue(chat);
        }
    }
    

}

[Serializable]
public class Chat
{
    //employees is case sensitive and must match the string "employees" in the JSON.
    public string Message;
    public bool Question;

}

[Serializable]
public class Chats
{
    //employees is case sensitive and must match the string "employees" in the JSON.
    public Chat[] chats;
}