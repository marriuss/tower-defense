using UnityEngine;
using Agava.YandexGames;

public class RewardedAds : MonoBehaviour
{
    [SerializeField, Min(1)] private int _rewardAmount;
    [SerializeField] private GameAudio _audio;
    [SerializeField] private Player _player;
    [SerializeField] private RaycastTarget _raycastTarget;

    public void Show()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        if (YandexGamesSdk.IsInitialized)
            ShowYandexVideo();
#endif
    }

    private void ShowYandexVideo()
    {
        VideoAd.Show(
            onErrorCallback: null,
            onOpenCallback: () =>
            {
                _raycastTarget.gameObject.SetActive(true);
                _audio.MuteMusic();
            },
            onRewardedCallback: () => _player.Balance.AddMoney(_rewardAmount),
            onCloseCallback: () =>
            {
                _raycastTarget.gameObject.SetActive(false);
                _audio.UnmuteMusic();
            }
        ) ;
    }
}
