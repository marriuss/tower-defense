using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FullscreenAds))]
public class FullscreenAdsShower : MonoBehaviour
{
    [SerializeField, Min(0)] private int _cooldown;

    private FullscreenAds _fullscreenAds;
    private int _adsShowed;

    private void Awake()
    {
        _adsShowed = 0;
        _fullscreenAds = GetComponent<FullscreenAds>();
    }

    public void ShowFullscreenAds()
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
