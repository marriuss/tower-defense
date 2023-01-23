using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform), typeof(CanvasGroup))]
public class CardDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public event UnityAction<CardDrag> Returned;
    public event UnityAction<CardDrag> DragStarted;

    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private Canvas _canvas;
    private Card _card;
    private bool _isPlaced;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Init(Card card, Canvas canvas)
    {
        _card = card;
        _canvas = canvas;
    }

    public Card Card => _card;

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(_canvas.transform, true);
        _canvasGroup.blocksRaycasts = false;
        _isPlaced = false;
        DragStarted?.Invoke(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;

        if (_isPlaced == false)
        {
            Return();
        }
    }

    public void Place(Transform slotTransform)
    {
        transform.SetParent(slotTransform, false);
        _rectTransform.anchoredPosition = Vector2.zero;
        _isPlaced = true;
    }

    public void Return()
    {
        Returned?.Invoke(this);
    }
}
