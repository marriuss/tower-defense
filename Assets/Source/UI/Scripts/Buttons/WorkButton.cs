using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class WorkButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    protected void SetInteractable(bool interactable)
    {
        _button.interactable = interactable;
    }

    protected abstract void OnButtonClick();
}
