using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Agava.YandexGames;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private Initializer _initializer;
    [SerializeField] private TMP_Text _loadingText;
    [SerializeField] private MapSceneLoadButton _loadButton;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AuthorizationButton _authorizationButton;

    private bool _gameInitialized;
    private bool _settingsInitialized;
    private bool _playerInitialized;

    private void Update()
    {
        _gameInitialized = _initializer.GameInitialized;
        _settingsInitialized = _initializer.SettingsInitialized;
        _loadButton.gameObject.SetActive(_gameInitialized && _settingsInitialized);
        _loadingText.gameObject.SetActive(!_gameInitialized && _settingsInitialized);
        _audio.gameObject.SetActive(_settingsInitialized);

#if UNITY_WEBGL && !UNITY_EDITOR
        _playerInitialized = YandexGamesSdk.IsInitialized && PlayerAccount.IsAuthorized;
#else
        _playerInitialized = true;
#endif

        _authorizationButton.gameObject.SetActive(_gameInitialized && !_playerInitialized);
    }
}
