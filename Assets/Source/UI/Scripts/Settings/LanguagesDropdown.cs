using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;
using TMPro;
using System;

[RequireComponent(typeof(TMP_Dropdown))]
public class LanguagesDropdown : MonoBehaviour
{
    [SerializeField] private List<LanguageNativeName> _languages;
    [SerializeField] private SettingsApplier _settingsApplier;

    private TMP_Dropdown _dropdown;
    
    private void Awake()
    {
        _dropdown = GetComponent<TMP_Dropdown>();
        _dropdown.options.Clear();

        foreach (LanguageNativeName language in _languages)
        {
            _dropdown.options.Add(new TMP_Dropdown.OptionData(language.Name));
        }
    }

    private void OnEnable()
    {
        _dropdown.onValueChanged.AddListener(OnValueChanged);
        _dropdown.value = _languages.FindIndex(language => language.Language == SettingsApplier.Language);
    }

    private void OnDisable()
    {
        _dropdown.onValueChanged.RemoveListener(OnValueChanged);
    }

    private void OnValueChanged(int index)
    {
        LeanLanguage language = _languages[index].Language;
        _settingsApplier.SetLanguageSettings(language);
    }
}

[Serializable]
internal struct LanguageNativeName
{
    [SerializeField] LeanLanguage _language;
    [SerializeField] string _name;

    public LeanLanguage Language => _language;
    public string Name => _name;
}