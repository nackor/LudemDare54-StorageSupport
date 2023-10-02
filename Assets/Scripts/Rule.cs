using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule : MonoBehaviour
{
    public List<string> Extensions = new List<string>();
    public int MinSize = -1;
    public DateTime OldestTime = DateTime.Now.AddDays(300);
    public string DissallowedWord = "Victor";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool PassesRule(Item item)
    {
        if((Extensions.Contains(item.Extension)))
        {
            return false;
        }
        if (item.Size < MinSize && MinSize != -1)
        {
            return false;
        }
        if (item.Name.Contains(DissallowedWord))
        {
            return false;
        }
        if(item.Date > OldestTime)
        {
            //too old
            return false;
        }
        return true;
    }
}
