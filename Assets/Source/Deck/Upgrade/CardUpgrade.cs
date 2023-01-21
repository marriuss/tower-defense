using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CardUpgrade : MonoBehaviour
{
    public event UnityAction CardUpgraded;

    private Button _button;
    private Card _card;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    public void Init(Card card)
    {
        _card = card;
        _button = GetComponent<Button>();
        _button.interactable = _card.CanUpLevel;
    }

    private void OnButtonClick()
    {
        if (_card.TryUpLevel())
        {
            CardUpgraded?.Invoke();
        }

        _button.interactable = _card.CanUpLevel;
    }
}
