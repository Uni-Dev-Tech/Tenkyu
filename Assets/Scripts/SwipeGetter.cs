using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeGetter : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public ObjectRotation obj_1;
    public ObjectRotation obj_2;
    public float resultX, resultY;
    public float sens;
    static public SwipeGetter instance;
    private void Awake()
    {
        if(SwipeGetter.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        SwipeGetter.instance = this;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.delta.x > 0)
        {
            resultX = eventData.delta.x * sens;
        }
        else
            resultX = eventData.delta.x * sens;
        if (eventData.delta.y > 0)
        {
            resultY = eventData.delta.y * sens;
        }
        else
            resultY = eventData.delta.y * sens;
    }

    public void OnDrag(PointerEventData eventData)
    {

    }
}
