using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Lean.Localization;

public class LocalizedText : MonoBehaviour
{
    private LeanLocalizedTextMeshProUGUI _lean;

    private void Awake()
    {
        _lean = GetComponent<LeanLocalizedTextMeshProUGUI>();
    }

    public void SetPhrase(LeanPhrase phrase)
    {
        LeanTranslation translation = LeanLocalization.GetTranslation(phrase.gameObject.name);
        _lean.TranslationName = translation.Name;
    }
}
