using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public abstract class CardSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null 
            && eventData.pointerDrag.TryGetComponent(out CardDrag cardDrag))
        {
            OnCardDrop(cardDrag);
        }
    }

    protected virtual void OnCardDrop(CardDrag cardDrag) { }
}
