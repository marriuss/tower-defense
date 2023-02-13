using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

[RequireComponent(typeof(Image))]
public class FightCardManaView : MonoBehaviour
{
    [SerializeField] private TMP_Text _manaText;
    [SerializeField] private List<RaritySprites> _raritySprites;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void Render(int manaCost, Rarity rarity)
    {
        _manaText.text = manaCost.ToString();
        Sprite sprite = _raritySprites.FirstOrDefault(item => item.Rarity == rarity).Sprite;

        if (sprite != null)
            _image.sprite = sprite;
    }
}

[Serializable]
public struct RaritySprites
{
    [SerializeField] private Rarity _rarity;
    [SerializeField] private Sprite _sprite;

    public Rarity Rarity => _rarity;
    public Sprite Sprite => _sprite;
}