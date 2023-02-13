using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TopCardView : MonoBehaviour
{
    [SerializeField] private TMP_Text _stackCountText;
    [SerializeField] private List<RaritySprites> _raritySprites;

    private Image _image;

    private void Awake()
    {
       _image = GetComponent<Image>();
    }

    public void Render(int count, int capacity, Rarity rarity)
    {
        _stackCountText.text = $"{count}/{capacity}";

        Sprite sprite = _raritySprites.FirstOrDefault(item => item.Rarity == rarity).Sprite;

        if (sprite != null)
            _image.sprite = sprite;
    }
}
