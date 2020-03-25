using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SavingFunctionality
{
    public static string settingsDestination = Application.persistentDataPath + "/settings.bin";
    public static string playerSaveDestination = Application.persistentDataPath + "/save0.bin";

    public static PlayerSave[] GetSaves()
    {
        PlayerSave[] saves =
            {
            LoadPlayer(1),
            LoadPlayer(2),
            LoadPlayer(3)
        };
        return saves;
    }

	#region SavingLoadingPlayer
	public static void SavePlayer(PlayerData playerData, byte saveSlot)
    {
        FileStream fileStream;
        playerSaveDestination = Application.persistentDataPath + $"/save{saveSlot}.bin";

        if (File.Exists(playerSaveDestination))
        {
            fileStream = File.OpenWrite(playerSaveDestination);
        }
        else
        {
            fileStream = File.Create(playerSaveDestination);
        }
        PlayerSave playerSave = new PlayerSave(playerData, saveSlot);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fileStream, playerSave);
        fileStream.Close();
    }

    public static void SavePlayer(PlayerSave playerSave)
    {
        FileStream fileStream;
        playerSaveDestination = Application.persistentDataPath + $"/save{playerSave.SaveSlot}.bin";

        if (File.Exists(playerSaveDestination))
        {
            fileStream = File.OpenWrite(playerSaveDestination);
        }
        else
        {
            fileStream = File.Create(playerSaveDestination);
        }

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fileStream, playerSave);
        fileStream.Close();
    }

    public static PlayerSave LoadLatestPlayer()
    {
        FileStream file;

        if (File.Exists(playerSaveDestination))
        {
            file = File.OpenRead(playerSaveDestination);
        }
        else
        {
            Debug.LogError("File not found");
            return null;
        }

        BinaryFormatter bf = new BinaryFormatter();
        PlayerSave data = (PlayerSave)bf.Deserialize(file);
        file.Close();

        return data;
    }

    public static PlayerSave LoadPlayer(byte saveSlot)
    {
        FileStream file;
        playerSaveDestination = Application.persistentDataPath + $"/save{saveSlot}.bin";

        if (File.Exists(playerSaveDestination)) file = File.OpenRead(playerSaveDestination);
        else
        {
            Debug.LogError("File not found");
            return null;
        }

        BinaryFormatter bf = new BinaryFormatter();
        PlayerSave data = (PlayerSave)bf.Deserialize(file);
        file.Close();

        return data;
    }
	#endregion

	#region SavingLoadingSettings
	public static void SaveSettings(SettingsData settingsData)
    {
        settingsData.LatestSave = playerSaveDestination;

        FileStream fileStream;

        if (File.Exists(settingsDestination))
        {
            fileStream = File.OpenWrite(settingsDestination);
        }
        else
        {
            fileStream = File.Create(settingsDestination);
        }

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fileStream, settingsData);
        fileStream.Close();
    }

    public static SettingsData LoadSettingsFile()
    {
        FileStream file;

        if (File.Exists(settingsDestination))
        {
            file = File.OpenRead(settingsDestination);
        }
        else
        {
            Debug.LogError("File not found");
            return null;
        }

        BinaryFormatter bf = new BinaryFormatter();
        SettingsData data = (SettingsData)bf.Deserialize(file);
        file.Close();

        playerSaveDestination = data.LatestSave;
        return data;
    }
	#endregion
}