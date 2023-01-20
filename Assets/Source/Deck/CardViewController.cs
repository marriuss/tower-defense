using UnityEngine;
using UnityEngine.UI;

public class CardViewController : MonoBehaviour
{
    [SerializeField] private CardRenderer _cardRenderer;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private CardDrag _cardDrag;

    private Card _card;

    public void Init(Card card, Canvas canvas)
    {
        _card = card;
        _cardRenderer.Init(_card);
        _cardDrag.Init(canvas);
    }
}
