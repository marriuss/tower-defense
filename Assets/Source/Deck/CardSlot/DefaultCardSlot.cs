public class DefaultCardSlot : CardSlot
{
    private CardDrag _cardDrag;

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
    }

    private void OnCradDragStarted(CardDrag cardDrag)
    {
        cardDrag.DragStarted -= OnCradDragStarted;
        _cardDrag = null;
    }
}
