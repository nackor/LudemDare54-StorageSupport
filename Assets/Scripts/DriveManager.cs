using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    List<Drive> Drives;

    public string HoveredDrive;

    GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void DropFile(Item item)
    {
        foreach(Drive drive in Drives)
        {
            if(drive.Name == HoveredDrive)
            {
                if (drive.CanMove(item))
                {
                    gameManager.ItemMoved(true);
                    drive.LongCurrent += item.LongSize;
                }
                else
                {
                    gameManager.ItemMoved(false);

                }
            }
        }
        gameManager.GetComponent<FileGenerator>().FTPDrive.LongCurrent -= item.LongSize;
        Destroy(item.gameObject);
    }

    internal void ScanDrive(string drive)
    {
        foreach(Drive findDrive in Drives)
        {
            if(drive == findDrive.Name)
            {
                findDrive.BeingScanned = true;
            }
        }
    }

    internal void FinishScan(string currentDriveBeingScanned)
    {
        foreach (Drive findDrive in Drives)
        {
            if (currentDriveBeingScanned == findDrive.Name)
            {
                if (findDrive.BeenScanned == false)
                {
                    gameManager.UpdateScanTracker();
                }
                findDrive.BeenScanned = true;
                findDrive.BeingScanned = false;
                findDrive.LastScan = gameManager.CurrentTime();
                findDrive.SecurityTime.text = findDrive.LastScan.ToShortDateString();
            }
        }
    }
}
