using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : MonoBehaviour
{

    [SerializeField]
    Item ItemToMove;
    [SerializeField]
    List<ChatRecord> Chats;
    [SerializeField]
    Chatter Chatter;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginTicket()
    {
        Chatter.StartChatting(Chats[0]);
        
    }
}
