using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
public class SecurityScanner : MonoBehaviour
{
    [SerializeField]
    ToggleGroup Toggles;
    [SerializeField]
    GameObject CurrentScan;
    [SerializeField]
    TextMeshProUGUI DriveField;
    [SerializeField]
    Slider slider;

    GameManager gameManager;
    DriveManager driveManager;
    string currentDriveBeingScanned;

    [SerializeField]
    float MaxScanTime = 30f;

    float scanTime = 1;

    bool scanning;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        driveManager = FindObjectOfType<DriveManager>();
    }

    private void Update()
    {
        if(scanTime <= 0)
        {
            FinishScan();
        }
        if (scanning)
        {
            slider.value = 1 - scanTime / MaxScanTime;
            scanTime -= Time.deltaTime;
            
        }
    }

    public void Scan()
    {
        string selectedDrive = (Toggles.ActiveToggles().FirstOrDefault()).gameObject.name;
        currentDriveBeingScanned = selectedDrive;
        Toggles.gameObject.SetActive(false);
        CurrentScan.gameObject.SetActive(true);
        driveManager.ScanDrive(selectedDrive);
        DriveField.text = currentDriveBeingScanned;
        scanTime = MaxScanTime;
        scanning = true;
    }

    public void FinishScan()
    {
        Toggles.gameObject.SetActive(true);
        CurrentScan.gameObject.SetActive(false);
        driveManager.FinishScan(currentDriveBeingScanned);
        scanning = false;
        scanTime = 1;
    }
}
