using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;

public class SettingsApplier : MonoBehaviour
{
    [SerializeField] private Settings _settings;

    private void Update()
    {
        LeanLocalization.SetCurrentLanguageAll(_settings.Language.name);
    }
}
