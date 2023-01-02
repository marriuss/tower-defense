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
        _playerProgress = new PlayerProgress();
        ProgressLoaded?.Invoke(_playerProgress);
    }
}
