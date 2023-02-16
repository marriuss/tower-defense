using UnityEngine;
using UnityEngine.UI;

public class CardRenderer : MonoBehaviour
{
    [SerializeField] private CardBackground _cardBackground;
    [SerializeField] private LocalizedText _nameText;
    [SerializeField] private Image _icon;

    public void Display(Card card)
    {
        _nameText.SetPhrase(card.CardInfo.Name);
        _icon.sprite = card.CardInfo.Icon;
        _cardBackground.Init(card.CardInfo.Rarity);
    }
}
