using UnityEngine;
using UnityEngine.UI;

public class CardViewController : MonoBehaviour
{
    [SerializeField] private CardRenderer _cardRenderer;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private CardDrag _cardDrag;
    [SerializeField] private CardUpgrade _cardUpgrade;

    private Card _card;

    public void Init(Card card, Canvas canvas)
    {
        _card = card;
        _cardDrag.Init(_card, canvas);
        _cardUpgrade.Init(_card);
        _cardRenderer.Display(_card);

        _cardUpgrade.CardUpgraded += OnCardUpgraded;
    }

    private void OnDestroy()
    {
        _cardUpgrade.CardUpgraded -= OnCardUpgraded;
    }

    private void OnCardUpgraded()
    {
        _cardRenderer.Display(_card);
    }
}
