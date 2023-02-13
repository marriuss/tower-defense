using UnityEngine;

[RequireComponent(typeof(FullscreenAds))]
public class FullscreenAdsShower : MonoBehaviour
{
    [SerializeField, Min(0)] private int _cooldown;

    private static int _adsShowed = 0;

    private FullscreenAds _fullscreenAds;

    private void Awake()
    {
        _fullscreenAds = GetComponent<FullscreenAds>();
    }

    private void Start()
    {
        if (_adsShowed == _cooldown)
        {
            _adsShowed = 0;
            _fullscreenAds.Show();
        }
        else
        {
            _adsShowed++;
        }
    }
}
