using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private bool _isDrag;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            _isDrag = false;
            transform.localPosition = Vector2.zero;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (!_isDrag)
        {
            return;
        }
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector2.zero;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _isDrag = true;
    }
}
