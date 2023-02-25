public static class CardCost
{
    private const int RegularCardCost = 75;
    private const int RareCardCost = 150;
    private const int LegendCardCost = 375;

    public static int RandomCardCost => (RegularCardCost + RareCardCost + LegendCardCost) / 3;

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
