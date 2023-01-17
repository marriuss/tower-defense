using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class NumberOutOfNumberView : MonoBehaviour
{
    private TMP_Text _textContainer;

    private void Awake()
    {
        _textContainer = GetComponent<TMP_Text>();
    }

    public void SetNumbers(int firstNumber, int secondNumber)
    {
        _textContainer.text = $"{firstNumber}/{secondNumber}";
    }
}
