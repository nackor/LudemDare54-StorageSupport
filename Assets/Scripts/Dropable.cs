using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public DriveManager DriveManager;
    public void OnPointerEnter(PointerEventData eventData)
    {
        DriveManager.HoveredDrive = gameObject.name;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        DriveManager.HoveredDrive = "";
    }

    // Start is called before the first frame update
    void Start()
    {
        DriveManager = FindObjectOfType<DriveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
