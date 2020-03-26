using System;
using System.Security.Cryptography;

[Serializable]
class PlayerSaveWrapper
{
    public PlayerData PlayerSaveData;
    public byte SaveSlot;

    public PlayerSaveWrapper(PlayerData player, byte saveSlot)
    {
        PlayerSaveData = player;
        this.SaveSlot = saveSlot;
    }
}

[Serializable]
public class PlayerData
{
    public int Health;
    public string HelperString = "";
    public PlayerData(int health, string helperString)
    {
        this.Health = health;
        this.HelperString = helperString;
    }

    public PlayerData(int health)
    {
        this.Health = health;
        RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
        byte[] vs = new byte[10];
        rNGCryptoServiceProvider.GetBytes(vs);
        foreach (byte item in vs)
        {
            HelperString += Convert.ToChar(item).ToString();
        }
    }

    public override string ToString()
    {
        return base.ToString();
    }
}