using System.Linq;
using UnityEngine;
using Lean.Localization;

[RequireComponent(typeof(LeanLocalization))]
public class LanguageIdentifier : MonoBehaviour
{
    private LeanLocalization _lean;
    private LeanLanguage[] _languages;

    public LeanLocalization Lean => _lean;

    private void Awake()
    {
        _lean = GetComponent<LeanLocalization>();
        _languages = GetComponentsInChildren<LeanLanguage>();
    }

    public LeanLanguage IdentifyLanguageByCode(string code)
    {
        LeanLanguage resultLanguage = _languages.FirstOrDefault(language => language.TranslationCode == code);

        if (resultLanguage == null)
            resultLanguage = _languages.FirstOrDefault(language => language.name == _lean.DefaultLanguage);

        return resultLanguage;
    }
}