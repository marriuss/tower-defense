using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class Panel : MonoBehaviour
{
    public event UnityAction<Panel> PanelOpened;
    public event UnityAction<Panel> PanelClosed;

    [SerializeField] private Button _openButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private GameObject _panelView;

    private void Awake()
    {
        _panelView.SetActive(false);
    }

    private void OnEnable()
    {
        _openButton.onClick.AddListener(OnOpenButtonClick);
        _closeButton.onClick.AddListener(OnCloseButtonClick);
        OnEnabled();
    }

    private void OnDisable()
    {
        _openButton.onClick.RemoveListener(OnOpenButtonClick);
        _closeButton.onClick.RemoveListener(OnCloseButtonClick);
        OnDisabled();
    }

    protected virtual void OnEnabled() { }
    protected virtual void OnDisabled() { }

    private void OnOpenButtonClick()
    {
        _panelView.SetActive(true);
        PanelOpened?.Invoke(this);
    }

    private void OnCloseButtonClick()
    {
        _panelView.SetActive(false);
        PanelClosed?.Invoke(this);
    }
}
