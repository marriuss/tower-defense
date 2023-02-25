using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CardBackground : MonoBehaviour
{
    [SerializeField] private Sprite _regularBackground;
    [SerializeField] private Sprite _rareBackground;
    [SerializeField] private Sprite _legendBackground;

    private Image _backgroundImage;

    public void Init(Rarity rarity)
    {
        _backgroundImage = GetComponent<Image>();
        Sprite backgroundSprite;

        switch (rarity)
        {
            case Rarity.RARE:
                backgroundSprite = _rareBackground;
                break;
            case Rarity.LEGEND:
                backgroundSprite = _legendBackground;
                break;
            case Rarity.REGULAR:
            default:
                backgroundSprite = _regularBackground;
                break;
        }

        _backgroundImage.sprite = backgroundSprite;
    }
}
