using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform), typeof(CanvasGroup))]
public class CardDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public event UnityAction<CardDrag> Placed;

    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private Canvas _canvas;

    private Transform _startParentTransform;
    private bool _isPlaced;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Init(Canvas canvas)
    {
        _canvas = canvas;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _startParentTransform = transform.parent;
        transform.SetParent(_canvas.transform, true);
        _canvasGroup.blocksRaycasts = false;
        _isPlaced = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_isPlaced == false)
        {
            ReturnToStartPlace();
        }

        _canvasGroup.blocksRaycasts = true;
    }

    private void ReturnToStartPlace()
    {
        transform.SetParent(_startParentTransform, false);
        _rectTransform.anchoredPosition = Vector2.zero;
    }

    public void Place(RectTransform slotRectTransform)
    {
        transform.SetParent(slotRectTransform, false);
        _rectTransform.anchoredPosition = Vector2.zero;
        _isPlaced = true;
        Placed?.Invoke(this);
    }
}
