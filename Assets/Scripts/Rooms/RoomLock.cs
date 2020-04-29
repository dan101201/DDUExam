using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLock : MonoBehaviour
{
    Roomreveal parentRoom;
    bool open = true;
    Transform[] cullases;

    void Awake()
    {
        parentRoom = GetComponentInParent<Roomreveal>();
        cullases = new Transform[transform.childCount];
        for (int i = 0; i < cullases.Length; i++)
        {
            cullases[i] = transform.GetChild(i).transform;
        }
    }

    void FixedUpdate()
    {
        int deadCount = 0;
        foreach (GameObject enemy in parentRoom.enemies)
        {
            if (enemy == null)
            {
                deadCount++;
            }
        }

        if (!open)
        {
            if (parentRoom.playerIsInRoom && parentRoom.enemies.Count == deadCount)
            {
                open = true;
                OpenCullases();
            }
        }
        else if (parentRoom.playerIsInRoom && parentRoom.enemies.Count != deadCount)
        {
            open = false;
            CloseCullases();
        }
    }

    void CloseCullases()
    {
        for (int i = 0; i < cullases.Length; i++)
        {
            cullases[i].localPosition = new Vector3(cullases[i].localPosition.x, 2.4f, cullases[i].localPosition.z);
        }
    }

    void OpenCullases()
    {
        for (int i = 0; i < cullases.Length; i++)
        {
            cullases[i].localPosition = new Vector3(cullases[i].localPosition.x, -5.5f, cullases[i].localPosition.z);
        }
    }
}
