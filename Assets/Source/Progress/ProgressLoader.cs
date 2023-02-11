using UnityEngine;
using UnityEngine.Events;

public class ProgressLoader : MonoBehaviour
{
    public UnityAction ProgressLoaded;

    private PlayerProgress _playerProgress;

    private void Start()
    {
        LoadProgress();
    }

    private void LoadProgress()
    {
        ProgressLoaded?.Invoke();
    }
}
