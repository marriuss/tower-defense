public static class CardCost
{
    private static readonly int RegularCardCost = 50;
    private static readonly int RareCardCost = 100;
    private static readonly int LegendCardCost = 250;

    public static int GetCardCost(Card card)
    {
        switch (card.CardInfo.Rarity)
        {
            case Rarity.REGULAR:
                return RegularCardCost;
            case Rarity.RARE:
                return RareCardCost;
            case Rarity.LEGEND:
                return LegendCardCost;
        }

        return -1;
    }
}
