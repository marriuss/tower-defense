using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DeckCardView : CardPointerEnterExitDetector
{
    public event UnityAction<DeckCardView> NeedCheckForReturn;

    [SerializeField] private CardDrag _cardDrag;
    [SerializeField] private CardRenderer _cardRenderer;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private CardUpgrade _cardUpgrade;

    private Card _card;

    public Card Card => _card;

    private void OnEnable()
    {
        _cardDrag.NeedCheckForReturn += OnCardNeedCheckForReturn;
        _cardUpgrade.CardUpgraded += OnCardUpgraded;
    }

    private void OnDisable()
    {
        _cardDrag.NeedCheckForReturn -= OnCardNeedCheckForReturn;
        _cardUpgrade.CardUpgraded -= OnCardUpgraded;
    }

    public void Init(Card card, Canvas canvas)
    {
        SetCard(card);
        _card = card;
        _cardDrag.Init(canvas);
        _cardUpgrade.Init(_card);
        _cardRenderer.Display(_card);
        
    }

    private void OnCardUpgraded()
    {
        _cardRenderer.Display(_card);
    }

    private void OnCardNeedCheckForReturn(CardDrag cardDrag)
    {
        NeedCheckForReturn?.Invoke(this);
    }
}
