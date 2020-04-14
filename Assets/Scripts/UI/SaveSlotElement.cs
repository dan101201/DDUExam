using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
#if UNITY_EDITOR
using UnityEditor.UI;
using UnityEditor;
#endif

public class SaveSlotElement : Button
{
    public byte SaveSlot;
    public Text NumberText;
    public Text SaveText;

    protected override void Start()
    {
        base.Start();
        NumberText.text = SaveSlot.ToString();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
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
        SaveText.text = playerData.HelperString;
    }
}

#if UNITY_EDITOR
#region EditorStuff
[CustomEditor(typeof(SaveSlotElement))]
public class SaveSlotElementEditor : ButtonEditor
{
    public override void OnInspectorGUI()
    {
        // Show default inspector property editor
        base.OnInspectorGUI();

        SaveSlotElement targetSaveSlot = (SaveSlotElement)target;

        targetSaveSlot.SaveSlot = (byte)EditorGUILayout.IntField("SaveSlot Number", targetSaveSlot.SaveSlot);

        targetSaveSlot.NumberText = (Text)EditorGUILayout.ObjectField("SaveNumber Text Field", targetSaveSlot.NumberText, typeof(Text), true);

        targetSaveSlot.SaveText = (Text)EditorGUILayout.ObjectField("SaveText Text Field", targetSaveSlot.SaveText, typeof(Text), true);
    }
}
#endregion
#endif