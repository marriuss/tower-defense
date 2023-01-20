using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardRenderer : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _manaText;
    [SerializeField] private TMP_Text _experienceText;
    [SerializeField] private Image _icon;

    public void Init(Card card)
    {
        _levelText.text = card.Level.ToString();
        _nameText.text = card.CardInfo.name;
        _manaText.text = card.CardInfo.Mana.ToString();
        _icon.sprite = card.CardInfo.Icon;
        _experienceText.text =
            string.Format("{0}/{1}", card.ExperiencePoints, card.ExperiencePointsRequired);
    }
}
