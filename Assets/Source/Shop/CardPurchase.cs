using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CardPurchase : MonoBehaviour
{
    public event UnityAction<CardPurchase> CardPurchased;

    [SerializeField] private TMP_Text _costText;
    [SerializeField] private GameObject _foreground;

    private int _cost;
    private Button _button;

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    public void Init(int cost, Balance balance, bool isUnlocked)
    {
        if (_button == null)
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClicked);
        }

        if (isUnlocked)
        {
            _foreground.SetActive(true);
            _button.gameObject.SetActive(false);
            return;
        }

        _cost = cost;
        _button.interactable = balance.HasEnoughMoney(_cost);
        _costText.text = _cost.ToString();
    }

    public void OnButtonClicked()
    {
        CardPurchased?.Invoke(this);
    }
}
