using UnityEngine;

public class StartCardSlot : CardSlot
{
    [SerializeField] private CardDrag _cardDrag;

    private void OnEnable()
    {
        _cardDrag.Returned += OnCardReturned;
    }

    private void OnDisable()
    {
        _cardDrag.Returned -= OnCardReturned;
    }

    protected override void OnCardDrop(CardDrag cardDrag)
    {
        if (_cardDrag != cardDrag)
        {
            return;
        }

        cardDrag.Place(transform);
    }

    private void OnCardReturned(CardDrag cardDrag)
    {
        if (_cardDrag != cardDrag)
        {
            return;
        }

        cardDrag.Place(transform);
    }
}
