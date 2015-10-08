using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

// Boy Voesten

public class ItemData : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{

    public Item item;
    public int amount = 1;
    public int slotID;

    private Tooltip _tooltip;
    private Transform _originalParent;
    private Inventory _inv;
    private Vector2 _offset;
    

    void Start()
    {
        _inv = GameObject.FindGameObjectWithTag(TagList.Inventory).GetComponent<Inventory>();
        _tooltip = _inv.GetComponent<Tooltip>();
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

    public void OnPointerEnter(PointerEventData eventData) 
    {
        if (item != null) 
        {
            _tooltip.Activate(item);
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (item != null) 
        {
            _tooltip.Deactivate();
        }
    }
}
