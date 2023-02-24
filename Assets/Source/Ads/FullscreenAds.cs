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
            onErrorCallback: null,
            onOpenCallback: () =>
            {
                _audio.MuteMusic();
            },
            onCloseCallback: (bool _) =>
            {
                _audio.UnmuteMusic();
            }
        );
    }
}
