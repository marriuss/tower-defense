using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class CardSlot : MonoBehaviour, IDropHandler
{
    public event UnityAction<CardSlot, DeckCardView> CardPlaced;
    public event UnityAction<CardSlot, DeckCardView> Freed;

    private Transform _cardViewParent;
    private RectTransform _cardViewRectTransform;
    private DeckCardView _cardView;

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
        _cardViewRectTransform = cardView.GetComponent<RectTransform>();
        _cardViewParent = _cardViewRectTransform.parent;
        RectTransform rectTransform = GetComponent<RectTransform>();
        _cardViewRectTransform.SetParent(rectTransform);
        _cardViewRectTransform.anchoredPosition = Vector2.zero;
        cardView.GetComponent<CardDrag>().DragStarted += OnCradDragStarted;
    }

    private void OnCradDragStarted(CardDrag cardDrag)
    {
        Free(cardDrag);
    }

    private void Free(CardDrag cardDrag)
    {
        Freed?.Invoke(this, _cardView);
        _cardViewRectTransform.SetParent(_cardViewParent);
        cardDrag.DragStarted -= OnCradDragStarted;
        _cardView = null;
        _cardViewParent = null;
    }
}
