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
        if (GetInputState() == EInputState.MouseKeyboard)
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
        else if (GetInputState() == EInputState.Controller)
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

    public enum EInputState
    {
        MouseKeyboard,
        Controller
    };
    private EInputState m_State = EInputState.MouseKeyboard;

    //*************************//
    // Unity member methods    //
    //*************************//

    /*void OnGUI()
    {
        switch (m_State)
        {
            case EInputState.MouseKeyboard:
                if (IsControlerInput())
                {
                    m_State = EInputState.Controller;
                    Debug.Log("DREAM - JoyStick being used");
                }
                break;
            case EInputState.Controller:
                if (IsMouseKeyboard())
                {
                    m_State = EInputState.MouseKeyboard;
                    Debug.Log("DREAM - Mouse & Keyboard being used");
                }
                break;
        }
    }*/

    //***************************//
    // Public member methods     //
    //***************************//

    public EInputState GetInputState()
    {
        return m_State;
    }

    //****************************//
    // Private member methods     //
    //****************************//

    public void IsMouseKeyboard()
    {
        // mouse & keyboard buttons
        if (Event.current.isKey ||
            Event.current.isMouse)
        {
            return;
        }
        // mouse movement
        if (Input.GetAxis("Mouse X") != 0.0f ||
            Input.GetAxis("Mouse Y") != 0.0f)
        {
            return;
        }
        return;
    }

    public void IsControlerInput()
    {
        // joystick buttons
        if (Input.GetKey(KeyCode.Joystick1Button0) ||
           Input.GetKey(KeyCode.Joystick1Button1) ||
           Input.GetKey(KeyCode.Joystick1Button2) ||
           Input.GetKey(KeyCode.Joystick1Button3) ||
           Input.GetKey(KeyCode.Joystick1Button4) ||
           Input.GetKey(KeyCode.Joystick1Button5) ||
           Input.GetKey(KeyCode.Joystick1Button6) ||
           Input.GetKey(KeyCode.Joystick1Button7) ||
           Input.GetKey(KeyCode.Joystick1Button8) ||
           Input.GetKey(KeyCode.Joystick1Button9) ||
           Input.GetKey(KeyCode.Joystick1Button10) ||
           Input.GetKey(KeyCode.Joystick1Button11) ||
           Input.GetKey(KeyCode.Joystick1Button12) ||
           Input.GetKey(KeyCode.Joystick1Button13) ||
           Input.GetKey(KeyCode.Joystick1Button14) ||
           Input.GetKey(KeyCode.Joystick1Button15) ||
           Input.GetKey(KeyCode.Joystick1Button16) ||
           Input.GetKey(KeyCode.Joystick1Button17) ||
           Input.GetKey(KeyCode.Joystick1Button18) ||
           Input.GetKey(KeyCode.Joystick1Button19))
        {
            return;
        }

        // joystick axis
        /*if (Input.GetAxis("XC Left Stick X") != 0.0f ||
           Input.GetAxis("XC Left Stick Y") != 0.0f ||
           Input.GetAxis("XC Triggers") != 0.0f ||
           Input.GetAxis("XC Right Stick X") != 0.0f ||
           Input.GetAxis("XC Right Stick Y") != 0.0f)
        {
            return true;
        }*/

        return;
    }
}