using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceShip : MonoBehaviour
{
    private DefaultActionMap actionMap;
    private InputAction move;
    private InputAction rotation;
    private InputAction upDown;
    public Rigidbody rb;
    public float thrust;
    public float rotationSpeed;
    
    public float rotationSmoothness = 10f;


    public void Awake()
    {
        actionMap = new DefaultActionMap();
        rb = GetComponent<Rigidbody>();
    }

    public void OnEnable()
    {
        move = actionMap.SpaceShip.Move;
        rotation = actionMap.SpaceShip.Rotation;
        upDown = actionMap.SpaceShip.UpDown;
        upDown.Enable();
        rotation.Enable();
        move.Enable();

    }
    public void OnDisable()
    {
        upDown.Disable();
        move.Disable();
        rotation.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovementShipManager();
    }

    public void MovementShipManager()
    {
        // move forwards backwards

        float movement = Move();
        Vector3 moveForce = new Vector3(0, 0, -movement);
        rb.AddRelativeForce(moveForce * thrust * Time.deltaTime);

        if (Mathf.Approximately(movement, 0f) == false)
        {
            //rotation
            float rotate = Rotation();
            float rotationAmount = rotate * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, rotationAmount);
        }


        //Up Down
        float upDown = UpDown();
        Vector3 UpDownStrenght = new Vector3(0, -upDown, 0);
        rb.AddForce(UpDownStrenght * thrust * Time.deltaTime);
    }
    public float UpDown()
    {
        return upDown.ReadValue<float>();
    }

    public float Rotation()
    {
        return rotation.ReadValue<float>();
    }

    public float Move()
    {
        return move.ReadValue<float>();
    }
}
