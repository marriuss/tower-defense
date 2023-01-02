using UnityEngine;
using UnityEngine.Events;

public class LevelsInitializer : MonoBehaviour
{
    public UnityAction<LevelButton> CurrentLevelChanged;

    [SerializeField] private LevelButton[] _levelButtons;
}
