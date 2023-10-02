using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TicketTracker : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    TextMeshProUGUI GoodMovesField;
    [SerializeField]
    TextMeshProUGUI BadMovesField;
    [SerializeField]
    TextMeshProUGUI DrivesScannedField;
    public int GoodMoves;
    public int BadMoves;

    public int drivesScanned=0;
    void Start()
    {
        GoodMoves = 0;
        BadMoves = 0;


    }

    // Update is called once per frame
    void Update()
    {
        GoodMovesField.text = GoodMoves.ToString();
        BadMovesField.text = BadMoves.ToString();
    }

    internal void IncrementScanTracker()
    {
        drivesScanned++;
        DrivesScannedField.text = drivesScanned.ToString() + "/3";
    }
}
