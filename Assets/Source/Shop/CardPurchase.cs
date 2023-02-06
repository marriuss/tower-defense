using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CardPurchase : MonoBehaviour
{
    public event UnityAction<CardPurchase> CardPurchased;

    [SerializeField] private CardRenderer _cardRenderer;
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private GameObject _foreground;
    [SerializeField] private Button _purchaseButton;

    private int _cost;
    private Balance _balance;
    private Card _card;

    private void OnEnable()
    {
        _purchaseButton.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _purchaseButton.onClick.RemoveListener(OnButtonClicked);
    }

    public void Init(Card card, Balance balance)
    {
        _balance = balance;
        _card = card;
        _cardRenderer.Display(_card);
        _cost = CardCost.GetCardCost(_card);
        _costText.text = _cost.ToString();
        UpdateView();
    }

    public void UpdateView()
    {
        _purchaseButton.interactable = _balance.HasEnoughMoney(_cost);

        if (_card.IsUnlocked)
        {
            SetLock(true);
            return;
        }

        SetLock(false);
    }

    private void SetLock(bool isLock)
    {
        _foreground.SetActive(isLock);
        _purchaseButton.gameObject.SetActive(!isLock);
    }

    public void OnButtonClicked()
    {
        if (_balance.TrySpend(_cost) == false)
        {
            return;
        }

        _card.Unlock();
        CardPurchased?.Invoke(this);
    }
}
