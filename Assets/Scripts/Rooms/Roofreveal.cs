using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roofreveal : MonoBehaviour
{
    MeshRenderer Roof;
    public bool RoofState;

    void Start()
    {
        Roof = GetComponent<MeshRenderer>();
        RoofState = Roof.enabled;
    }

    public void ChangeRoofState()
    {
        RoofState = !RoofState;
        Roof.enabled = RoofState;
    }

    public void ChangeRoofState(bool newState)
    {
        RoofState = newState;
        Roof.enabled = RoofState;
    }
}
