using System.Collections.Generic;
using System.Linq;

public static class CardSorter
{
    public static IEnumerable<Card> SortCardsByRarity(IEnumerable<Card> cards, bool descending = false)
    {
        static Rarity cardRarity(Card card) => card.CardInfo.Rarity;
        IEnumerable<Card> result = descending ? cards.OrderByDescending(cardRarity) : cards.OrderBy(cardRarity);
        return result;
    }
}
