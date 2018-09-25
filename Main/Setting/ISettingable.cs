namespace Main
{
    public interface ISettingable
    {
        string GetConfig(string key);
        bool SetConfig(string key, string value);
    }
}
