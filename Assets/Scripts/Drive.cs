using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class Drive : MonoBehaviour
{

    [SerializeField]
    public string Name;
    [SerializeField]
    public int MaxSize;
    public float CurrentSize = 20;

    [NonSerializedAttribute]
    public int LongMax = (int)(20 * Math.Pow(10, 7));
    [NonSerializedAttribute]
    public int LongCurrent = (int)(20 * Math.Pow(10, 6)); 

    [SerializeField]
    public List<Rule> Rules;
    public LinkedList<Item> items;

    public bool BeingScanned = false;

    public bool BeenScanned = false;

    [SerializeField]
    public TextMeshProUGUI SecurityTime;

    public DateTime LastScan;
    // Start is called before the first frame update
    void Start()
    {
        LongMax = (int)(MaxSize * Math.Pow(10, 6));
        LongCurrent = (int)(CurrentSize * Math.Pow(10, 6));
        items = new LinkedList<Item>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentSize = (float)(LongCurrent / Math.Pow(10, 6));
    }

    public bool CanMove(Item item)
    {
        if(item.LongSize + LongCurrent >= LongMax && Name != "Trash")
        {
            return false;
        }
        if (BeingScanned)
        {
            //throw event that ticket failed
            return false;
        }
        foreach(Rule rule in Rules)
        {
            if (!rule.PassesRule(item))
            {
                //throw event ticket failed
                return false;
            }
        }
        return true;
    }


}
