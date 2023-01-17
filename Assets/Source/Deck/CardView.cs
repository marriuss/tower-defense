using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _manaText;
    [SerializeField] private TMP_Text _experienceText;
    [SerializeField] private Image _icon;

    private Card _card;

    public void Init(Card card)
    {
        _card = card;
        _levelText.text = _card.Level.ToString();
        _nameText.text = _card.CardInfo.name;
        _manaText.text = _card.CardInfo.Mana.ToString();
        _icon.sprite = _card.CardInfo.Icon;
        _experienceText.text = 
            string.Format("{0}/{1}", _card.ExperiencePoints, _card.ExperiencePointsRequired);
    }
}
