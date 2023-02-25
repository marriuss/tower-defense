using UnityEngine;

[RequireComponent(typeof(CardPointerEnterExitDetector))]
public class CardUpgradeButtonController : MonoBehaviour
{
    [SerializeField] private GameObject _upgradeButton;

    private CardPointerEnterExitDetector _pointerDetector;

    private void Awake()
    {
        _pointerDetector = GetComponent<CardPointerEnterExitDetector>();
    }

    private void OnEnable()
    {
        _pointerDetector.PointerEntered += OnPointerEntered;
        _pointerDetector.PointerExited += OnPointerExited;
    }

    private void OnDisable()
    {
        _pointerDetector.PointerEntered -= OnPointerEntered;
        _pointerDetector.PointerExited -= OnPointerExited;
    }

    private void Start()
    {
        SetSelection(false);
    }

    private void OnPointerEntered(Card card)
    {
        SetSelection(true);
    }

    private void OnPointerExited(Card cardCard)
    {
        SetSelection(false);
    }

    private void SetSelection(bool isSelected)
    {
        _upgradeButton.SetActive(isSelected);
    }
}
