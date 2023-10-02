using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragable : MonoBehaviour, IDragHandler, IPointerClickHandler, IPointerUpHandler
{

    Vector2 oldOffset;
    // Start is called before the first frame update
    void Start()
    {
        oldOffset = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {

        if (oldOffset == Vector2.zero)
        {
            oldOffset = eventData.position;
            return;
        }
        Vector2 offset = eventData.position - oldOffset;
        oldOffset = eventData.position;
        transform.position = transform.position + (Vector3)offset;
        transform.SetAsLastSibling();
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.SetAsLastSibling();
    }

   
    public void OnPointerUp(PointerEventData eventData)
    {
        oldOffset = Vector2.zero;
    }
}
