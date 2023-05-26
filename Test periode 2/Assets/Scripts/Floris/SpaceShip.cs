using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceShip : MonoBehaviour
{
    public Rigidbody rb;

    public float vechileStrenght;
    public float rollTourge;
    public float rotationXSensetivity;
    public float rotationYSensetivity;



    private DefaultActionMap defaultActionMap;
    private InputAction roll;
    private InputAction move;
    private InputAction mousePosition;


    public GameObject smallSquare;
    public bool cursorOverSquare = false;

    private void Awake()
    {
        defaultActionMap = new DefaultActionMap();
    }
    private void OnEnable()
    {
        roll = defaultActionMap.SpaceShip.Roll;
        move = defaultActionMap.SpaceShip.Move;
        mousePosition = defaultActionMap.SpaceShip.LookMovement;
        mousePosition.Enable();
        move.Enable();
        roll.Enable();

    }

    private void OnDisable()
    {
        roll.Disable();
        move.Disable();
        mousePosition.Disable();

    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovementManagerShip();


    }
    public void MovementManagerShip()
    {
        if (cursorOverSquare)
        {
            rb.angularVelocity = Vector3.Lerp(rb.angularVelocity, Vector3.zero, Time.deltaTime);
            Vector2 moveValue = Move();
            Vector3 moveForce = new Vector3(moveValue.x, 0, moveValue.y);
            rb.AddRelativeForce(vechileStrenght * moveForce * Time.deltaTime);
        }
        else
        {
            //Barrel Rol
            float roll = Roll();
            Vector3 rollForce = new Vector3(0, 0, -roll);
            rb.AddRelativeTorque(rollForce * rollTourge * Time.deltaTime);

            //movement
            Vector2 moveValue = Move();
            Vector3 moveForce = new Vector3(moveValue.x, 0, moveValue.y);
            rb.AddRelativeForce(vechileStrenght * moveForce * Time.deltaTime);

            //Rotation
            Vector2 mousePosition = LookMovement();
            float screenHalfWidth = Screen.width / 2;
            float screenHalfHeight = Screen.height / 2;
            Vector2 cursorScreenMiddle = new Vector2(-(screenHalfWidth - mousePosition.x), -(screenHalfHeight - mousePosition.y));
            float rotationX = Mathf.Clamp(cursorScreenMiddle.x / screenHalfWidth, -1, 1);
            float rotationY = Mathf.Clamp(cursorScreenMiddle.y / screenHalfHeight, -1, 1);
            Vector2 rotation = new Vector2(rotationX, rotationY);


            Vector3 rotationXForce = new Vector3(-rotation.y, 0, 0);
            rb.AddRelativeTorque(rotationXSensetivity * rotationXForce * Time.deltaTime);

            Vector3 rotationYforce = new Vector3(0, rotation.x, 0);
            rb.AddRelativeTorque(rotationYSensetivity * rotationYforce * Time.deltaTime);
            Debug.Log("" + rotationX);
            Debug.Log("" + rotationY);


        }


    }

    public float Roll()
    {
        return roll.ReadValue<float>();
    }

    public Vector2 Move()
    {
        return move.ReadValue<Vector2>();
    }

    public Vector2 LookMovement()
    {
        return mousePosition.ReadValue<Vector2>();
    }



    private void Update()
    {
        if (smallSquare != null)
        {
            RectTransform rectTransform = smallSquare.GetComponent<RectTransform>();
            Vector2 squarePosition = rectTransform.position;
            Vector2 cursorPosition = Mouse.current.position.ReadValue();

            if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, cursorPosition))
            {
                cursorOverSquare = true;
            }
            else
            {
                cursorOverSquare = false;
            }
        }
    }
}
