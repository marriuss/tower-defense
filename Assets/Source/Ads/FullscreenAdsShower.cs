using UnityEngine;

[RequireComponent(typeof(FullscreenAds))]
public class FullscreenAdsShower : MonoBehaviour
{
    [SerializeField, Min(0)] private int _cooldown;

    private FullscreenAds _fullscreenAds;

    private void Awake()
    {
        _fullscreenAds = GetComponent<FullscreenAds>();
    }

    private void Start()
    {
        if (MapSceneLoader.SceneLoadingCount % (_cooldown + 1) == 0)
            _fullscreenAds.Show();
    }
}
