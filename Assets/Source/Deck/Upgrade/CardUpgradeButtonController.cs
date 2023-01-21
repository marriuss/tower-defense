using UnityEngine;
using UnityEngine.EventSystems;

public class CardUpgradeButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject _upgradeButton;

    private void Start()
    {
        SetSelection(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetSelection(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetSelection(false);
    }

    private void SetSelection(bool isSelected)
    {
        _upgradeButton.SetActive(isSelected);
    }
}
