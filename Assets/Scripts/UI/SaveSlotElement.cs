using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SaveSlotElement : MonoBehaviour
{
    public Canvas canvas;
    public byte SaveSlot;
    Text SaveText;

    void Start()
    {
        Text[] texts = GetComponentsInChildren<Text>();
        texts[0].text = SaveSlot.ToString();
        SaveText = texts[1];
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayerData playerData = new PlayerData(2);
        SavingFunctionality.SavePlayer(playerData, SaveSlot);
        UpdateData(playerData);
    }

    public void DisplayEmptySlot()
    {
        SaveText.text = "Empty";
    }

    public void UpdateData(PlayerData playerData)
    {
        SaveText.text = playerData.ToString();
    }
}
