using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseIcon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Spawner;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Spawner.GetComponent<Item>().FinishDragging();
            Destroy(gameObject);
        }
        transform.position = Input.mousePosition;
    }


}
