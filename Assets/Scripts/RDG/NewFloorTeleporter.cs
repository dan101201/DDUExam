using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFloorTeleporter : MonoBehaviour
{
    public int RoomsWantedOffset = 5;
    public int TreasureRoomsWantedOffset = 2;
    private int floorNum = 1;
    private void OnTriggerEnter(Collider player)
    {  
        if (player.transform.tag == "Player") {
            player.transform.position = new Vector3(0, 0.605f, 0);
            var tempScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<DungeonGenerationScript>();
            tempScript.RemoveDungeon();
            tempScript.normalRoomsWanted += RoomsWantedOffset;
            tempScript.treasureRoomsWanted += TreasureRoomsWantedOffset;
            tempScript.Generate();
        }
    }

    IEnumerator NewFloorText() {
        var temp = GameObject.FindGameObjectWithTag("PickUpText");
        temp.GetComponent<UnityEngine.UI.Text>().text = "Floor " + floorNum;
        temp.SetActive(true);
        yield return new WaitForSeconds(2f);
        temp.SetActive(false);
    }
}
