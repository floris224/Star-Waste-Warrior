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

    public float maxDis = 5f;

    private DefaultActionMap defaultActionMap;
    private InputAction mouseDelta;
    private InputAction move;
    private InputAction roll;
    private InputAction upDown;

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
    }

    // Start is called before the first frame update
    void Start()
    {

        //Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        car = GameObject.Find("SpaceShip");
        if (car == null)
        {
            Debug.Log("Car not set");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float vDis = Vector3.Distance(transform.position, car.transform.position);

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
        Vector3 moveForce = new Vector3(-moveValue.x, 0f, moveValue.y);
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
