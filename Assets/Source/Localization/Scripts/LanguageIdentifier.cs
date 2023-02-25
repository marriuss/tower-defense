using System.Linq;
using UnityEngine;
using Lean.Localization;
using System;

[RequireComponent(typeof(LeanLocalization))]
public class LanguageIdentifier : MonoBehaviour
{
    private LeanLocalization _lean;
    private LeanLanguage[] _languages;

    private void Awake()
    {
        _lean = GetComponent<LeanLocalization>();
        _languages = GetComponentsInChildren<LeanLanguage>();
    }

    public LeanLanguage IdentifyLanguageByCode(string code)
    {
        string languageCode(LeanLanguage language) => language.TranslationCode;
        return IdentifyLanguageByFieldValue(languageCode, code);
    }

    public LeanLanguage IdentifyLanguageByName(string name)
    {
        string languageName(LeanLanguage language) => language.name;
        return IdentifyLanguageByFieldValue(languageName, name);
    }

    private LeanLanguage IdentifyLanguageByFieldValue(Func<LeanLanguage, string> languageField, string fieldValue)
    {
        LeanLanguage resultLanguage = _languages.FirstOrDefault(language => languageField(language) == fieldValue);

        if (resultLanguage == null)
            resultLanguage = FindByName(_lean.DefaultLanguage);

        return resultLanguage;
    }

    private LeanLanguage FindByName(string name)
    {
        return _languages.FirstOrDefault(language => language.name == name);
    }
}