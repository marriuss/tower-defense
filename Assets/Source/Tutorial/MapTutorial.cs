using UnityEngine;
using UnityEngine.UI;

public class MapTutorial : MonoBehaviour
{
    [SerializeField] private GameObject _tutorialPanel;
    [SerializeField] private Button _closeButton;

    private void Start()
    {
        _tutorialPanel.SetActive(true);
        _closeButton.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _tutorialPanel.SetActive(false);
        _closeButton.onClick.RemoveListener(OnButtonClick);
    }
}
