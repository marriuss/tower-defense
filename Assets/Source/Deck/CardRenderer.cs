using Lean.Localization;
using UnityEngine;
using UnityEngine.UI;

public class CardRenderer : MonoBehaviour
{
    [SerializeField] private CardBackground _cardBackground;
    [SerializeField] private LocalizedText _nameText;
    [SerializeField] private Image _icon;

    private LeanPhrase _namePhrase;

    private void Start()
    {
        _nameText.SetPhrase(_namePhrase);
    }

    public void Display(Card card)
    {
        _namePhrase = card.CardInfo.Name;
        _icon.sprite = card.CardInfo.Icon;
        _cardBackground.Init(card.CardInfo.Rarity);
    }
}
