using UnityEngine;
using UnityEngine.EventSystems;

// TODO: Place card only if slot if free

[RequireComponent(typeof(RectTransform))]
public class CardSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private CardDrag _cardDrag;

    private RectTransform _rectTransform;

    private void OnEnable()
    {
        if (_cardDrag != null)
        {
            _cardDrag.Placed += OnCardPlaced;
        }
    }

    private void OnDisable()
    {
        if (_cardDrag != null)
        {
            _cardDrag.Placed -= OnCardPlaced;
        }
    }

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private bool IsFree => _cardDrag == null;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null 
            && eventData.pointerDrag.TryGetComponent(out CardDrag cardDrag)
            && IsFree)
        {
            cardDrag.Place(_rectTransform);
            _cardDrag = cardDrag;
            _cardDrag.Placed += OnCardPlaced;
        }
    }

    private void OnCardPlaced(CardDrag cardDrag)
    {
        cardDrag.Placed -= OnCardPlaced;
        _cardDrag = null;
    }
}
