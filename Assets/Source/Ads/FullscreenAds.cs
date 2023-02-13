using UnityEngine;
using Agava.YandexGames;

public class FullscreenAds : MonoBehaviour
{
    [SerializeField] private GameAudio _audio;

    public void Show()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
    if (YandexGamesSdk.IsInitialized)
        ShowYandexVideo();
#endif
    }

    public void ShowYandexVideo()
    {
        InterstitialAd.Show(
            onOpenCallback: () =>
            {
                _audio.MuteMusic();
                Time.timeScale = 0.0f;
            },
            onCloseCallback: (bool _) =>
            {
                _audio.UnmuteMusic();
                Time.timeScale = 1.0f;
            }
        );
    }
}
