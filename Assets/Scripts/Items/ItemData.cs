using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

// Boy Voesten

    // TODO:
    //  Actually move the items, back-end wise (Putting the item into another 'slot' prefab)
    //  Data tooltip on hover

public class ItemData : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public Item item;
    public int amount = 1;

    private Transform _originalParent;
    private Vector2 _offset;

    public void OnPointerDown(PointerEventData eventData) 
    {
        if (item != null) 
        {
            _offset = eventData.position - new Vector2(transform.position.x, transform.position.y);
        }
    }

    public void OnBeginDrag(PointerEventData eventData) 
    {
        if (item != null) 
        {
            _originalParent = transform.parent;
            transform.SetParent(transform.parent.parent);
            transform.position = eventData.position - _offset;
        }
    }

    public void OnDrag(PointerEventData eventData) 
    {
        if (item != null) 
        {
            transform.position = eventData.position - _offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData) 
    {
        if (item != null)
        {
            transform.SetParent(_originalParent);
            transform.position = _originalParent.transform.position;
        }
        //throw new System.NotImplementedException();
    }
}
