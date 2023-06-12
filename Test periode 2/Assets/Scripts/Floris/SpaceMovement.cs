using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class SpaceMovement : MonoBehaviour
{

    public float rollTorque;
    public float thrust;
    public float rotationXSensitivity;
    public float rotationYSensitivity;

    public Rigidbody rb;
    public GameObject car;

    public float maxDis;

    private DefaultActionMap defaultActionMap;
    private InputAction mouseDelta;
    private InputAction move;
    private InputAction roll;
    private InputAction upDown;
    public InputAction boost;
    public ControllerSwitch controllerSwitch;
    public float vDis;

    private bool isBoosting = false;

    private void Awake()
    {
        defaultActionMap = new DefaultActionMap();
        
       
    }

    private void OnEnable()
    {
        mouseDelta = defaultActionMap.PlayerSpace.LookMovement;
        move = defaultActionMap.PlayerSpace.Move;
        roll = defaultActionMap.PlayerSpace.Roll;
        upDown = defaultActionMap.PlayerSpace.UpDown;
        boost = defaultActionMap.PlayerSpace.Boost;

        boost.started += BoostStarted;
        boost.performed += boostPerformed;
        boost.canceled += boostCanceld;

        boost.Enable();
        mouseDelta.Enable();
        move.Enable();
        roll.Enable();
        upDown.Enable();
    }

    private void OnDisable()
    {
        mouseDelta.Disable();
        move.Disable();
        roll.Disable();
        upDown.Disable();
        boost.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {

        //Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        car = GameObject.Find("SpaceShip");
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (controllerSwitch.doesPlayerSpaceExist == true)
        {
            vDis = Vector3.Distance(transform.position, car.transform.position);
        }
        else
        {
            vDis = 0;
        }
        

        if (vDis <= maxDis)
        {
            MovementManager();
            
        }
        else if (vDis >= maxDis)
        {
            Vector3 dirCar = (car.transform.position - transform.position).normalized;
            float pullStrenght = Mathf.Clamp01((vDis - maxDis) / maxDis) * rb.mass;
            rb.AddForce(dirCar * pullStrenght);
        }
    }
    public void MovementManager()
    {
        float roll = Roll();
        Vector3 rollForce = new Vector3(0f, 0f, -roll);
        rb.AddRelativeTorque(rollForce * rollTorque * Time.deltaTime);

        Vector2 moveValue = Move();
        Vector3 moveForce = new Vector3(moveValue.x, 0f, moveValue.y);
        rb.AddRelativeForce(moveForce * thrust * Time.deltaTime);

        float upDown = UpDown();
        Vector3 UpDownStrenght = new Vector3(0, -upDown, 0);
        rb.AddForce(UpDownStrenght * thrust * Time.deltaTime);

        Vector2 cursorPosition = CursorPosition();
        float screenWidthHalf = Screen.width / 2f;
        float screenheightHalf = Screen.height / 2f;
        Vector2 cursorPositionFromCenter = new Vector2(-(screenWidthHalf - cursorPosition.x), -(screenheightHalf - cursorPosition.y));
        float rotationX = Mathf.Clamp(cursorPositionFromCenter.x / screenWidthHalf, -1f, 1f);
        float rotationY = Mathf.Clamp(cursorPositionFromCenter.y / screenheightHalf, -1f, 1f);
        Vector2 rotation = new Vector2(rotationX, rotationY);

        Vector3 rotationXForce = new Vector3(-rotation.y, 0f, 0f);
        rb.AddRelativeTorque(rotationXForce * rotationXSensitivity * Time.deltaTime);

        Vector3 rotationYForce = new Vector3(0f, rotation.x, 0f);
        rb.AddRelativeTorque(rotationYForce * rotationYSensitivity * Time.deltaTime);

    }
    private void BoostStarted(InputAction.CallbackContext context)
    {
        
    }

    private void boostPerformed(InputAction.CallbackContext context)
    {
        isBoosting = true;
        BoostInput();
        Debug.Log("Input");
    }
    private void boostCanceld(InputAction.CallbackContext context)
    {
        isBoosting = false;
        BoostInput();
    }   

/*
action.started += context => Debug.Log($"{context.action} started");
action.performed += context => Debug.Log($"{context.action} performed");
action.canceled += context => Debug.Log($"{context.action} canceled");
*/
    public float BoostInput()
    {
        if (isBoosting)
        {
          thrust *= 2;
            //button Down

        }
        else
        {
            thrust /= 2;
            // button up.
        }
       
        return boost.ReadValue<float>();
    }

    public Vector2 CursorPosition()
    {
        return mouseDelta.ReadValue<Vector2>();
    }

    public Vector2 Move()
    {
        return move.ReadValue<Vector2>();
    }

    public float Roll()
    {
        return roll.ReadValue<float>();
    }
    public float UpDown()
    {
        return upDown.ReadValue<float>();
    }
}
