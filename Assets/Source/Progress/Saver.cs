public abstract class Saver
{
    protected string Key;

    public Saver(string key)
    {
        Key = key;
    }

    public static Saver GetSaver(string key) => new PlayerPrefsSaver(key);

    public abstract void Save(string value);

    public abstract string Load();
}
