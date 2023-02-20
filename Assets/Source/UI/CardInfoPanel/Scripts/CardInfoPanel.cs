using Lean.Localization;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardInfoPanel : MonoBehaviour
{
    private const string MaxLevelSign = "Max";

    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private LocalizedText _nameText;
    [SerializeField] private TMP_Text _experienceText;
    [SerializeField] private TMP_Text _manaText;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _damageText;
    [SerializeField] private TMP_Text _armorText;
    [SerializeField] private TMP_Text _speedText;
    [SerializeField] private TMP_Text _attackRangeText;
    [SerializeField] private TMP_Text _attackDelayText;

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
        CardInfo cardInfo = card.CardInfo;
        UnitStats unitStats = card.CardInfo.Unit.Stats;

        _levelText.text = card.Level.ToString();
        _experienceText.text = card.IsMaxLevel ? MaxLevelSign : string.Format("{0}/{1}", card.ExperiencePoints, card.ExperiencePointsRequired);
        _namePhrase = cardInfo.Name;
        _manaText.text = cardInfo.Mana.ToString();

        _healthText.text = unitStats.Health.ToString();
        _damageText.text = unitStats.Damage.ToString();
        _armorText.text = unitStats.Armor.ToString();
        _speedText.text = string.Format("{0:f1}", unitStats.Speed);
        _attackRangeText.text = string.Format("{0:f1}", unitStats.AttackRange);
        _attackDelayText.text = string.Format("{0:f1}", unitStats.AttackDelay);

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
