using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CardPointerEnterExitDetector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public event UnityAction<Card> PointerEntered;
    public event UnityAction<Card> PointerExited;

    private Card _targetCard;

    public void SetCard(Card card)
    {
        _targetCard = card;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PointerEntered?.Invoke(_targetCard);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PointerExited?.Invoke(_targetCard);
    }
}
