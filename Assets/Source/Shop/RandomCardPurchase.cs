using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RandomCardPurchase : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private Button _purchaseButton;
    [SerializeField] private GameObject _foreground;

    private List<CardPurchase> _cardPurchases;

    private void OnEnable()
    {
        _purchaseButton.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _purchaseButton.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _cardPurchases.Count; i++)
        {
            _cardPurchases[i].CardPurchased -= OnCardPurchased;
        }
    }

    public void Init(List<CardPurchase> cardPurchases)
    {
        _costText.text = CardCost.RandomCardCost.ToString();
        _cardPurchases = cardPurchases;

        for (int i = 0; i < _cardPurchases.Count; i++)
        {
            _cardPurchases[i].CardPurchased += OnCardPurchased;
        }

        transform.SetAsLastSibling();
        UpdateView();
    }

    public void UpdateView()
    {
        _purchaseButton.interactable = _player.Balance.HasEnoughMoney(CardCost.RandomCardCost);
        
        if (_cardPurchases.Count == 0)
        {
            _foreground.SetActive(true);
        }

        _foreground.SetActive(false);
    }

    private void OnButtonClicked()
    {
        if (_player.Balance.TrySpend(CardCost.RandomCardCost) == false)
        {
            return;
        }

        CardPurchase cardPurchase = _cardPurchases[Random.Range(0, _cardPurchases.Count)];
        cardPurchase.UnlockCard();
    }

    private void OnCardPurchased(CardPurchase cardPurchase)
    {
        cardPurchase.CardPurchased -= OnCardPurchased;
        _cardPurchases.Remove(cardPurchase);
    }
}
