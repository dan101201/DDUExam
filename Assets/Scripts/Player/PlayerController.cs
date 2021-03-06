﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;

    Rigidbody playerRigidbody;
    LayerMask aimingLayerMask;
    PlayerInput PlayerInput;
    Transform shootingDirector;

    private EInputState m_State;

    void Start()
    {
        aimingLayerMask = LayerMask.GetMask("PlayerAiming");
        playerRigidbody = GetComponent<Rigidbody>();
        PlayerInput = GetComponent<PlayerInput>();
        InputSystem.onDeviceChange += (device, change) =>
        {
            switch (change)
            {
                case InputDeviceChange.Added:
                    Debug.Log($"Device {device} was added");
                    m_State = EInputState.Controller;
                    break;
                case InputDeviceChange.Removed:
                    Debug.Log($"Device {device} was removed");
                    m_State = EInputState.MouseKeyboard;
                    break;
            }
        };
        shootingDirector = GameObject.FindWithTag("ShootingDirector").transform;
    }

    private void FixedUpdate()
    {
        playerRigidbody.velocity = Vector3.Normalize(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"))) * movementSpeed;

        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(camRay, out RaycastHit hitPlacement, 100f, aimingLayerMask))
        {
            Vector3 playerToMouse = hitPlacement.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
    }
    
    enum EInputState
    {
        MouseKeyboard,
        Controller
    };
}