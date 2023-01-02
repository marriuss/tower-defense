using UnityEngine;

public class LevelProgress : MonoBehaviour
{
    private Saver _saver = Saver.GetSaver("LevelProgress");

    public void SetLastOpenedLevelIdentifier(int levelIdentifier)
    {
        _saver.Save(levelIdentifier.ToString());
    }

    public int GetLastOpenedLevelIdentifier()
    {
        if (int.TryParse(_saver.Load(), out int levelIdentifier))
        {
            return levelIdentifier;
        }

        return 0;
    }
}
