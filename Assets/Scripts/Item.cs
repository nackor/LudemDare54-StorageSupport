using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;

public class Item : MonoBehaviour, IDragHandler
{
    public float Size = 0;
    public int LongSize;
    public string SizeMeasurement = "";
    public string Name = "";
    public string Extension = "";
    public DateTime Date = DateTime.Now;
    public Drive Drive;
    public Folder Parent;

    [SerializeField]
    public Image folderImage;
    [SerializeField]
    public Image fileImage;
    [SerializeField]
    public Image pictureImage;

    [SerializeField]
    public TextMeshProUGUI NameField;
    [SerializeField]
    public TextMeshProUGUI TypeField;
    [SerializeField]
    public TextMeshProUGUI DateField;
    [SerializeField]
    public TextMeshProUGUI SizeField;

    public MouseIcon Icon;

    private bool spawned;
    Canvas canvas;

    DriveManager driveManager;
    public void Start()
    {
        canvas = FindAnyObjectByType<Canvas>();
        GetComponent<RectTransform>().sizeDelta = new Vector2(1,1);
        driveManager = FindObjectOfType<DriveManager>();    

    }

    public void Update()
    {
        NameField.text = Name;
        DateField.text = Date.ToShortDateString();
        SizeField.text = (Size).ToString("##.#") + " " + SizeMeasurement;
        TypeField.text = Extension;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //spawn same image at mouse
        if (!spawned)
        {
            MouseIcon newIcon = Instantiate(Icon,canvas.transform);
            newIcon.GetComponentInChildren<Image>().sprite = GetComponentInChildren<Image>().sprite;
            spawned = true;
            newIcon.transform.SetAsLastSibling();
            newIcon.Spawner = gameObject;
        }
    }

    public void SetSize(int realSize)
    {
        LongSize = realSize;
        if(SizeMeasurement == "KB")
        {
            Size = (float)(realSize / Math.Pow(10, 0));
        }
        if(SizeMeasurement == "MB")
        {
            Size = (float)(realSize / Math.Pow(10, 3));
        }
        if(SizeMeasurement == "GB")
        {
            Size = (float)(realSize / Math.Pow(10, 6));
        }
    }
    public void FinishDragging()
    {
        spawned = false;
        if (driveManager.HoveredDrive == "") 
        { 
            //not hovering a dropable, return
            return; 
        }
        driveManager.DropFile(this);
        
    }
}


