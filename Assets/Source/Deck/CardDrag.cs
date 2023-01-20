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

    private Vector2 _startPosition;
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
        _startPosition = _rectTransform.anchoredPosition;
        _isPlaced = false;
        _startParentTransform = transform.parent;
        transform.SetParent(_canvas.transform, true);
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_isPlaced == false)
        {
            _rectTransform.anchoredPosition = _startPosition;
        }

        transform.SetParent(_startParentTransform, false);
        _canvasGroup.blocksRaycasts = true;
    }

    public void Place()
    {
        _isPlaced = true;
        Placed?.Invoke(this);
    }
}
