[System.Serializable]
public class SettingsData
{
    public bool VSync;
    public string LatestSave;

    public SettingsData(bool vSync, string latestSave)
    {
        this.VSync = vSync;
        this.LatestSave = latestSave;
    }
}
