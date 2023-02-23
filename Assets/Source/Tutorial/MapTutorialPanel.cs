public class MapTutorialPanel : Panel
{
    private bool SceneLoadedFirstTime => MapSceneLoader.SceneLoadingCount == 1;

    private void Start()
    {
        if (PlayerProgressStorage.HasSavings == false && SceneLoadedFirstTime)
        {
            Open();
        }
    }
}
