using UnityEngine;

public class RewardedAdsButton : WorkButton
{
    [SerializeField] private RewardedAds _rewardedAds;

    protected override void OnButtonClick()
    {
        _rewardedAds.Show();
    }
}
