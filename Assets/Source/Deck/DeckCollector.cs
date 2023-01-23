using UnityEngine;
using UnityEngine.InputSystem;

public class DeckCollector : MonoBehaviour
{
    [SerializeField] private DefaultCardSlot[] _slots;

    public Deck GetDeck()
    {
        Deck deck = new Deck();

        for (int i = 0; i < _slots.Length; i++)
        {
            deck.PlaceCard(_slots[i].Card, i);
        }

        return deck;
    }

    private void Update()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            var deck = GetDeck();
        }
    }
}
