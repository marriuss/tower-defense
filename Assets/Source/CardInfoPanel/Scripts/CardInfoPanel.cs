using Lean.Localization;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardInfoPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private LocalizedText _nameText;
    [SerializeField] private TMP_Text _experienceText;
    [SerializeField] private TMP_Text _manaText;
    [SerializeField] private Image _icon;

    private List<CardPointerEnterExitDetector> _cardPointerDetectors = new List<CardPointerEnterExitDetector>();
    private LeanPhrase _namePhrase;

    private void OnEnable()
    {
        if (_namePhrase == null)
        {
            return;
        }

        _nameText.SetPhrase(_namePhrase);
    }

    public void ReInit(List<CardPointerEnterExitDetector> cards)
    {
        for (int i = 0; i < _cardPointerDetectors.Count; i++)
        {
            _cardPointerDetectors[i].PointerEntered -= OnCardPointerEntered;
            _cardPointerDetectors[i].PointerExited -= OnCardPointerExited;
        }

        _cardPointerDetectors.Clear();
        _cardPointerDetectors = cards;

        for (int i = 0; i < _cardPointerDetectors.Count; i++)
        {
            _cardPointerDetectors[i].PointerEntered += OnCardPointerEntered;
            _cardPointerDetectors[i].PointerExited += OnCardPointerExited;
        }
    }

    private void DisplayCard(Card card)
    {
        _levelText.text = card.Level.ToString();
        _experienceText.text = string.Format("{0}/{1}", card.ExperiencePointsRequired, card.ExperiencePoints);
        _namePhrase = card.CardInfo.Name;
        _manaText.text = card.CardInfo.Mana.ToString();
        _icon.sprite = card.CardInfo.Icon;
        gameObject.SetActive(true);
    }

    private void Clear()
    {
        gameObject.SetActive(false);
        _namePhrase = null;
    }

    private void OnCardPointerEntered(Card card)
    {
        DisplayCard(card);
    }

    private void OnCardPointerExited(Card card)
    {
        Clear();
    }
}
