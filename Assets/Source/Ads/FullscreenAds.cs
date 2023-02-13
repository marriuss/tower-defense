using UnityEngine;
using Agava.YandexGames;

public class FullscreenAds : MonoBehaviour
{
    [SerializeField] private GameAudio _audio;

    public void ShowYandexVideo()
    {
        InterstitialAd.Show(
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
