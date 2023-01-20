using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardViewController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private CardRenderer[] _cardRenderers;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private CardDrag _cardDrag;

    private Card _card;

    public void Init(Card card, Canvas canvas)
    {
        _card = card;
        SetSelection(false);

        for (int i = 0; i < _cardRenderers.Length; i++)
        {
            _cardRenderers[i].Init(_card);
        }

        _cardDrag.Init(canvas);
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
