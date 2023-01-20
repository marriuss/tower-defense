using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardUpgrade : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Button _upgradeButton;

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
        _upgradeButton.gameObject.SetActive(isSelected);
    }
}
