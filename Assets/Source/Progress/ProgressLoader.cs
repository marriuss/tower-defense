using UnityEngine;
using UnityEngine.Events;

public class ProgressLoader : MonoBehaviour
{
    public UnityAction<PlayerProgress> ProgressLoaded;

    private PlayerProgress _playerProgress;

    private void Start()
    {
        LoadProgress();
    }

    private void LoadProgress()
    {
        _playerProgress = new PlayerProgress()
        {
            Money = 0,
            LastLevelId = 0,
            CardProgress = new CardProgress[0],
            CardIds = new int?[0],
            CastleLevel = 1,
        };

        ProgressLoaded?.Invoke(_playerProgress);
    }
}
