using System.Collections.Generic;
using System.Linq;

public static class CardSorter
{
    public static T SortCardsByRarity<T>(T cards, bool descending = false) where T : IEnumerable<Card>
    {
        static Rarity cardRarity(Card card) => card.CardInfo.Rarity;
        IEnumerable<Card> result = descending ? cards.OrderByDescending(cardRarity) : cards.OrderBy(cardRarity);
        return (T)result;
    }
}
