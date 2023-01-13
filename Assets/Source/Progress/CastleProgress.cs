public class CastleProgress
{
    public int Level;
    public int ExperiencePoints;

    public CastleProgress(int level, int experiencePoints) 
    {
        Level = level;
        ExperiencePoints = experiencePoints;
    }

    public CastleProgress()
    {
        Level = 1;
        ExperiencePoints = 0;
    }
}