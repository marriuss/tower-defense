using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class LevelsInitializer : MonoBehaviour
{
    [SerializeField] private LevelsPool _levelsPool;
    [SerializeField] private LevelButton[] _levelButtons;

    public UnityAction<LevelButton> CurrentLevelChanged;

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

    private void Start()
    {
        LevelButton button = _levelButtons.FirstOrDefault(l => l.LevelInfo.Id == _levelsPool.LastLevelId);

        if (button != null)
            CurrentLevelChanged?.Invoke(button);
    }

    private void OnLevelButtonClicked(LevelButton levelButton)
    {
        // TODO: open level
    }
}
