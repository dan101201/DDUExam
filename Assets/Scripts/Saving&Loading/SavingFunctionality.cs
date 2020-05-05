using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

public static class SavingFunctionality
{
    public static string settingsDestination = Application.persistentDataPath + "/settings.bin";
    public static string playerSaveDestination = Application.persistentDataPath + "/save0.bin";
    public static string logPath = Application.persistentDataPath + "/DebugLogging.txt";
    public static byte LatestSlot;

    public static PlayerData[] GetSaves()
    {
        PlayerData[] saves =
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
        PlayerSaveWrapper playerSave = new PlayerSaveWrapper(playerData, saveSlot);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fileStream, playerSave);
        fileStream.Close();
        LatestSlot = saveSlot;
    }

    public static PlayerData LoadLatestPlayer()
    {
        FileStream file;
        playerSaveDestination = Application.persistentDataPath + $"/save{LatestSlot}.bin";

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
        PlayerSaveWrapper data = (PlayerSaveWrapper)bf.Deserialize(file);
        file.Close();

        return data.PlayerSaveData;
    }

    public static PlayerData LoadPlayer(byte saveSlot)
    {
        FileStream file;
        playerSaveDestination = Application.persistentDataPath + $"/save{saveSlot}.bin";

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
        PlayerSaveWrapper data = (PlayerSaveWrapper)bf.Deserialize(file);
        file.Close();

        return data.PlayerSaveData;
    }
	#endregion

	#region SavingLoadingSettings
	public static void SaveSettings(SettingsSaveDataWrapper settingsData)
    {
        settingsData.LatestSaveSlot = LatestSlot;

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

    public static SettingsSaveDataWrapper LoadSettingsFile()
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
        SettingsSaveDataWrapper data = (SettingsSaveDataWrapper)bf.Deserialize(file);
        file.Close();

        LatestSlot = data.LatestSaveSlot;
        return data;
    }
	#endregion

	#region Logging
    public static void AddToLog(string log)
    {
        using (StreamWriter sw = new StreamWriter(logPath, true))
        {
            sw.WriteLine(log);
        }
    }
	#endregion
}