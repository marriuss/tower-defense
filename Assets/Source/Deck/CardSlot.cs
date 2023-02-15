using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class CardSlot : MonoBehaviour, IDropHandler
{
    public event UnityAction<CardSlot, DeckCardView> CardPlaced;
    public event UnityAction<CardSlot, DeckCardView> Freed;

    private RectTransform _rectTransform;
    private DeckCardView _cardView;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null
            && eventData.pointerDrag.TryGetComponent(out DeckCardView cardView))
        {
            CardPlaced?.Invoke(this, cardView);
        }
    }

    public void PlaceCard(DeckCardView cardView)
    {
        _cardView = cardView;
        RectTransform rectTransform = cardView.GetComponent<RectTransform>();
        rectTransform.SetParent(_rectTransform);
        rectTransform.anchoredPosition = Vector2.zero;
        cardView.GetComponent<CardDrag>().DragStarted += OnCradDragStarted;
    }

    private void OnCradDragStarted(CardDrag cardDrag)
    {
        Free(cardDrag);
    }

    private void Free(CardDrag cardDrag)
    {
        Freed?.Invoke(this, _cardView);
        cardDrag.DragStarted -= OnCradDragStarted;
        _cardView = null;
    }
}
