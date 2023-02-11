using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class LevelsInitializer : MonoBehaviour
{
    public UnityAction<LevelButton> CurrentLevelChanged;

    [SerializeField] private LevelButton[] _levelButtons;
    [SerializeField] private ProgressLoader _progressLoader;

    private int _lastLevelId;

    private void OnEnable()
    {
        foreach (var levelButton in _levelButtons)
        {
            levelButton.ButtonClicked += OnLevelButtonClicked;
        }
    }

    private void OnDisable()
    {
        foreach (var levelButton in _levelButtons)
        {
            levelButton.ButtonClicked -= OnLevelButtonClicked;
        }
    }

    private void OnProgressLoaded(PlayerProgress progress)
    {
        _lastLevelId = progress.LastLevelId;
        CurrentLevelChanged?.Invoke(_levelButtons.First(l => l.LevelInfo.Id == _lastLevelId));
    }

    private void OnLevelButtonClicked(LevelButton levelButton)
    {
        // TODO: open level
    }
}
