public class DefaultCardSlot : CardSlot
{
    private CardDrag _cardDrag;

    public Card Card => _cardDrag?.Card;
    private bool IsBusy => _cardDrag != null;

    protected override void OnCardDrop(CardDrag cardDrag)
    {
        if (IsBusy)
        {
            _cardDrag.Return();
        }

        _cardDrag = cardDrag;
        _cardDrag.Place(transform);
        _cardDrag.DragStarted += OnCradDragStarted;
        _cardDrag.Returned += OnCradReturned;
    }

    private void OnCradDragStarted(CardDrag cardDrag)
    {
        Free(cardDrag);
    }

    private void OnCradReturned(CardDrag cardDrag)
    {
        Free(cardDrag);
    }

    private void Free(CardDrag cardDrag)
    {
        cardDrag.Returned -= OnCradReturned;
        cardDrag.DragStarted -= OnCradDragStarted;
        _cardDrag = null;
    }
}
