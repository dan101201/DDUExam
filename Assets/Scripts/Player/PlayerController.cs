using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public GameObject daEmpty;

    Rigidbody playerRigidbody;
    LayerMask aimingLayerMask;
    Vector3 north;
    PlayerInput PlayerInput;

    void Start()
    {
        aimingLayerMask = LayerMask.GetMask("PlayerAiming");
        playerRigidbody = GetComponent<Rigidbody>();
        Camera.main.transform.LookAt(transform);
        north = new Vector3(0, 0, 1);
        PlayerInput = GetComponent<PlayerInput>();
    }

    //Update is called once per 'tick'
    void FixedUpdate()
    {
        Debug.Log(PlayerInput.currentControlScheme);

        if (m_State == EInputState.MouseKeyboard)
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPlacement;

            if (Physics.Raycast(camRay, out hitPlacement, 100, aimingLayerMask))
            {
                /*daEmpty.transform.position = hitPlacement.point;
                daEmpty.transform.position = new Vector3(daEmpty.transform.position.x, 0, daEmpty.transform.position.z);
                transform.LookAt(daEmpty.transform);
                Debug.Log(transform.rotation.eulerAngles);*/
                /*daEmpty.transform.position = hitPlacement.point - transform.position;
                transform.eulerAngles = new Vector3(0, Vector3.Angle(north, daEmpty.transform.position), 0);*/
                Vector3 playerToMouse = hitPlacement.point - transform.position;
                playerToMouse.y = 0f;
                Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
                playerRigidbody.MoveRotation(newRotation);


                Debug.DrawRay(Camera.main.transform.position, camRay.direction);
            }

            Debug.Log("MouseKeyboard");
        }
        else if (m_State == EInputState.Controller)
        {
            Debug.Log("Controller");
        }
        else
        {
            Debug.Log("No Input");
        }

        playerRigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, 0, Input.GetAxis("Vertical") * movementSpeed);

        //Debug.Log(rigidbody.velocity);

        //Locally deprecated
        /*if (Input.GetKey("w"))
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey("s"))
        {
            transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey("a") && !Input.GetKey("d"))
        {
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey("d") && !Input.GetKey("a"))
        {
            transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
        }*/
    }

    //https://answers.unity.com/questions/131899/how-do-i-check-what-input-device-is-currently-beei.html
    //*********************//
    // Public member data  //
    //*********************//


    //*********************//
    // Private member data //
    //*********************//

    enum EInputState
    {
        MouseKeyboard,
        Controller
    };
    private EInputState m_State = EInputState.MouseKeyboard;
}