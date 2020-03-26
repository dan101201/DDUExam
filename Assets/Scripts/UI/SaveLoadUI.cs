using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadUI : MonoBehaviour
{
    public SaveSlotElement Save1;
    public SaveSlotElement Save2;
    public SaveSlotElement Save3;

    public PlayerData currentPlayer;

    void Start()
    {
        Save1.SaveSlot = 1;
        Save2.SaveSlot = 2;
        Save3.SaveSlot = 3;
        UpdateList();
    }

    public void UpdateList()
    {
        PlayerData[] saves = SavingFunctionality.GetSaves();
        if (saves[0] != null)
        {
            Save1.UpdateData(saves[0]);
        }
        else
        {
            Save1.DisplayEmptySlot();
        }

        if (saves[1] != null)
        {
            Save2.UpdateData(saves[0]);
        }
        else
        {
            Save2.DisplayEmptySlot();
        }

        if (saves[2] != null)
        {
            Save3.UpdateData(saves[0]);
        }
        else
        {
            Save3.DisplayEmptySlot();
        }
    }
}
