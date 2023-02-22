using UnityEngine;
using UnityEngine.UI;

public class MapTutorial : MonoBehaviour
{
    [SerializeField] private GameObject _tutorialPanel;
    [SerializeField] private Button _closeButton;

    private bool SceneLoadedFirstTime => MapSceneLoader.SceneLoadingCount == 1;

    private void Start()
    {
        if (PlayerProgressStorage.HasSavings == false && SceneLoadedFirstTime == true)
        {
            _tutorialPanel.SetActive(true);
            _closeButton.onClick.AddListener(OnButtonClick);
        }
    }

    private void OnButtonClick()
    {
        _tutorialPanel.SetActive(false);
        _closeButton.onClick.RemoveListener(OnButtonClick);
    }
}
