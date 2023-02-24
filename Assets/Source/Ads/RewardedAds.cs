using UnityEngine;
using Agava.YandexGames;

public class RewardedAds : MonoBehaviour
{
    [SerializeField, Min(1)] private int _rewardAmount;
    [SerializeField] private GameAudio _audio;
    //[SerializeField] private MenuGroup _menuGroup;
    [SerializeField] private Player _player;

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
            onOpenCallback: () =>
            {
                //_menuGroup.OpenRaycastTarget();
                _audio.MuteMusic();
            },
            onRewardedCallback: () => _player.Balance.AddMoney(_rewardAmount),
            onCloseCallback: () =>
            {
                //_menuGroup.CloseRaycastTarget();
                _audio.UnmuteMusic();
            }
        );
    }
}