using UnityEngine;

public class DeckPanel : Panel
{
    [SerializeField] private CardViewController[] cardViewControllers;
    [SerializeField] private Canvas _canvas;

    private void Start()
    {
        for (int i = 0; i < cardViewControllers.Length; i++)
        {
            cardViewControllers[i].Init(new Card(new CardInfo()), _canvas);
        }
    }
}
