public class CardProgress
{
    public int Id;
    public int Level;
    public int ExperiencePoints;
    public int? DeckIndex;

    public CardProgress(int id, int level, int experiencePoints, int? deckIndex)
    {
        Id = id;
        Level = level;
        ExperiencePoints = experiencePoints;
        DeckIndex = deckIndex;
    }
}
