using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private Initializer _initializer;
    [SerializeField] private TMP_Text _loadingText;
    [SerializeField] private MapSceneLoadButton _loadButton;
    [SerializeField] private AudioSource _audio;

    private bool _gameInitialized;
    private bool _settingsInitialized;

    private void Update()
    {
        _gameInitialized = _initializer.GameInitialized;
        _settingsInitialized = _initializer.SettingsInitialized;
        _loadButton.gameObject.SetActive(_gameInitialized && _settingsInitialized);
        _loadingText.gameObject.SetActive(!_gameInitialized && _settingsInitialized);
        _audio.gameObject.SetActive(_settingsInitialized);
    }
}
