using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEnder : MonoBehaviour
{
    Scorer scorer;

    [SerializeField]
    ChatRecord endChat;
    [SerializeField]
    Chatter chatter;

    [SerializeField]
    public TextMeshProUGUI PassedField;
    [SerializeField]
    public TextMeshProUGUI FailedField;
    [SerializeField]
    TextMeshProUGUI DrivesField;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        scorer = FindObjectOfType<Scorer>();
        StartCoroutine(scorer.EndGame());
        scorer.PassedField = PassedField;
        scorer.FailedField = FailedField;
        scorer.DrivesField = DrivesField;
    }
    void Update()
    {
        chatter.StartChatting(endChat);
        
    }

}
