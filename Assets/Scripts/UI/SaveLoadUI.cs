using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadUI : MonoBehaviour
{
    public SaveSlotElement Save1;
    public SaveSlotElement Save2;
    public SaveSlotElement Save3;

    void Start()
    {
        UpdateList();
    }

    public void UpdateList()
    {
        PlayerSave[] saves = SavingFunctionality.GetSaves();
        if (saves[0] != null)
        {
            Save1.saveSlot = 1;
            Text[] texts = Save1.GetComponentsInChildren<Text>();
            texts[0].text = saves[0].SaveSlot.ToString();
            texts[1].text = saves[0].PlayerSaveData.ToString();
        }
        else
        {
            Save1.saveSlot = 1;
            Text[] texts = Save1.GetComponentsInChildren<Text>();
            texts[0].text = "1";
            texts[1].text = "Empty";
        }

        if (saves[1] != null)
        {
            Save2.saveSlot = 2;
            Text[] texts = Save2.GetComponentsInChildren<Text>();
            texts[0].text = saves[1].SaveSlot.ToString();
            texts[1].text = saves[1].PlayerSaveData.ToString();
        }
        else
        {
            Save2.saveSlot = 2;
            Text[] texts = Save2.GetComponentsInChildren<Text>();
            texts[0].text = "2";
            texts[1].text = "Empty";
        }

        if (saves[2] != null)
        {
            Save3.saveSlot = 3;
            Text[] texts = Save3.GetComponentsInChildren<Text>();
            texts[0].text = saves[2].SaveSlot.ToString();
            texts[1].text = saves[2].PlayerSaveData.ToString();
        }
        else
        {
            Save3.saveSlot = 3;
            Text[] texts = Save3.GetComponentsInChildren<Text>();
            texts[0].text = "3";
            texts[1].text = "Empty";
        }
    }

    public void SaveToSelected(byte saveSlot)
    {
        switch (saveSlot)
        {
            case 1:
                SavingFunctionality.SavePlayer(new PlayerData(2), 1);
                break;
            case 2:
                SavingFunctionality.SavePlayer(new PlayerData(2), 2);
                break;
            case 3:
                SavingFunctionality.SavePlayer(new PlayerData(2), 3);
                break;
            default:
                Debug.LogError(saveSlot + "number not accepted!");
                break;
        }
    }
}
