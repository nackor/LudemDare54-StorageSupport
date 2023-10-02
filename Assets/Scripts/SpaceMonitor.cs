using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpaceMonitor : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI amountFree;

    [SerializeField]
    Slider slider;

    [SerializeField]
    Drive TargetDrive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        amountFree.text = (TargetDrive.MaxSize - TargetDrive.CurrentSize).ToString("####.##");
        slider.value =  (float)((float)TargetDrive.CurrentSize/(float)TargetDrive.MaxSize);
    }
}
