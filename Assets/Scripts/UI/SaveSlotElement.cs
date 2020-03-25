using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SaveSlotElement : MonoBehaviour
{
    public Canvas canvas;
    public byte saveSlot;

    public void OnPointerClick(PointerEventData eventData)
    {
        canvas.GetComponent<SaveLoadUI>().SaveToSelected(saveSlot);
    }

    public void UpdateData(PlayerSave save)
    {

    }
}

/*
#region EditorStuff
[CustomEditor(typeof(SaveSlotElement))]
public class SaveSlotEditor : ButtonEditor
{
    public override void OnInspectorGUI()
    {
        // Show default inspector property editor
        base.OnInspectorGUI();

        SaveSlotElement targetSaveSlot = (SaveSlotElement)target;

        targetSaveSlot.canvas = (Canvas)EditorGUILayout.ObjectField(targetSaveSlot.canvas, typeof(Canvas), true);

        targetSaveSlot.saveSlot = (byte)EditorGUILayout.IntField(targetSaveSlot.saveSlot);
    }
}
#endregion
*/
