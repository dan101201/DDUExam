using System;
using System.Security.Cryptography;
[Serializable]
public class PlayerSave
{
    public PlayerData PlayerSaveData;
    public byte SaveSlot;

    public PlayerSave(int health, byte saveSlot)
    {
        PlayerSaveData = new PlayerData(health);
        this.SaveSlot = saveSlot;
    }
    public PlayerSave(PlayerData player, byte saveSlot)
    {
        PlayerSaveData = player;
        this.SaveSlot = saveSlot;
    }
}

[Serializable]
public class PlayerData
{
    public int Health;
    public string location = "";
    public PlayerData(int health)
    {
        this.Health = health;
        RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
        byte[] vs = new byte[10];
        rNGCryptoServiceProvider.GetBytes(vs);
        foreach (byte item in vs)
        {
            location += Convert.ToChar(vs);
        }
    }

    public override string ToString()
    {
        return base.ToString();
    }
}