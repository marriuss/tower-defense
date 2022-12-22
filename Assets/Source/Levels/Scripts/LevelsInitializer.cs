using UnityEngine;

public class LevelsInitializer : MonoBehaviour
{
    [SerializeField] private LevelInfo[] _levelsInfo;
    [SerializeField] private LevelButton[] _levelButtons;

    private void Start()
    {
        InitLevels();
    }

    public void InitLevels()
    {
#if UNITY_EDITOR
        if (_levelsInfo.Length != _levelButtons.Length)
        {
            Debug.LogWarning("Incorrect levels data");
        }
#endif

        for (int i = 0; i < _levelButtons.Length; i++)
        {
            _levelButtons[i].Init(_levelsInfo[i]);
        }
    }
}
