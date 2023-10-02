using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatManager : MonoBehaviour
{

    [SerializeField]
    public List<TextMeshProUGUI> ChatField;
    [SerializeField]
    public int MaxChats = 7;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendChat(string message)
    {
        MoveChatsUp();
        ChatField[0].text = message;
    }

    private void MoveChatsUp()
    {
        string oldChat = "";
        string newChat = "";
        for(int i = 0; i <MaxChats; i++)
        {
            newChat = ChatField[i].text;
            ChatField[i].text = oldChat;
            oldChat = newChat;

        }
    }

    private void ClearChats()
    {
        for (int i = 0; i < MaxChats; i++)
        {
            ChatField[i].text = "";
        }
    }
}
