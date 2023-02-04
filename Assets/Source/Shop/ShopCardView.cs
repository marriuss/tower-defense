using UnityEngine;
using UnityEngine.Events;

public class ShopCardView : MonoBehaviour
{
    public event UnityAction<Card> CardPurchased;

    [SerializeField] private CardRenderer _cardRenderer;
    [SerializeField] private CardPurchase _cardPurchase;

    private Card _card;

    private void OnEnable()
    {
        _cardPurchase.CardPurchased += OnCardPurchased;
    }

    private void OnDisable()
    {
        _cardPurchase.CardPurchased -= OnCardPurchased;
    }

    public void Init(Card card, Balance balance)
    {
        _card = card;
        _cardRenderer.Display(_card);
        _cardPurchase.Init(CardCost.GetCardCost(_card), balance, card.IsUnlocked);
    }

    private void OnCardPurchased(CardPurchase cardPurchase)
    {
        _cardPurchase.CardPurchased -= OnCardPurchased;
        CardPurchased?.Invoke(_card);
    }
}
