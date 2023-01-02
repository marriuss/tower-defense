using UnityEngine;

public class PlayerPrefsSaver : Saver
{
    public PlayerPrefsSaver(string key) : base(key) { }

    public override void Save(string value)
    {
        PlayerPrefs.SetString(Key, value);
        PlayerPrefs.Save();
    }

    public override string Load()
    {
        return PlayerPrefs.GetString(Key, null);
    }
}
