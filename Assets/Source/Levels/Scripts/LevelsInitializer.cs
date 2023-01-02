using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class LevelsInitializer : MonoBehaviour
{
    public UnityAction<LevelButton> CurrentLevelChanged;

    [SerializeField] private LevelProgress _levelProgress;
    [SerializeField] private LevelInfo[] _levelsInfo;
    [SerializeField] private LevelButton[] _levelButtons;

    private LevelInfo _currentLevelInfo;

    private void Start()
    {
        InitLevels();
        ApplayProgress();
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

    private void ApplayProgress()
    {
        int lastOpenLevelIdentifier = _levelProgress.GetLastOpenedLevelIdentifier();
        _currentLevelInfo = _levelsInfo.First(level => level.Identifier == lastOpenLevelIdentifier);
        LevelButton currentLevelButton = _levelButtons.First(button => button.LevelInfo == _currentLevelInfo);
        CurrentLevelChanged?.Invoke(currentLevelButton);
    }
}
