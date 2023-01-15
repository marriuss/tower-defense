using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManaView : MonoBehaviour
{
    [SerializeField] private TMP_Text _manaValueText;
    [SerializeField] private ManaController _controller;

    private void Update()
    {
        _manaValueText.text = _controller.Mana.ToString();
    }
}
