using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

// Boy Voesten

// TODO:
//  Data tooltip on hover

public class ItemData : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Item item;
    public int amount = 1;
    public int slotID;

    private Transform _originalParent;
    private Inventory _inv;
    private Vector2 _offset;

    void Start()
    {
        _inv = GameObject.FindGameObjectWithTag(TagList.Inventory).GetComponent<Inventory>();
    }

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
            GetComponent<CanvasGroup>().blocksRaycasts = false;
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
            transform.SetParent(_inv.slots[slotID].transform);
            transform.position = _inv.slots[slotID].transform.position;
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
