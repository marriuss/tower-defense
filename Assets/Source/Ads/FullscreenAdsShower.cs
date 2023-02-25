using UnityEngine;

[RequireComponent(typeof(FullscreenAds))]
public class FullscreenAdsShower : MonoBehaviour
{
    [SerializeField, Min(0)] private int _cooldown;

    private FullscreenAds _fullscreenAds;
    private static int nextAdsSceneCount = 1;

    private void Awake()
    {
        _fullscreenAds = GetComponent<FullscreenAds>();
    }

    private void Start()
    {
        int loadingCount = MapSceneLoader.SceneLoadingCount;

        if (loadingCount == nextAdsSceneCount)
        {
            _fullscreenAds.Show();
            nextAdsSceneCount += _cooldown + 1;
        }
    }
}
