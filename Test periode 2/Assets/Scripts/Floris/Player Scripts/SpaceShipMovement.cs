using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceShipMovement : MonoBehaviour
{
    private DefaultActionMap actionMap;
    private InputAction move;
    private InputAction rotation;
    private InputAction upDown;
    private InputAction interact;
    public Rigidbody rb;
    public float thrust;
    public float rotationSpeed;
    public GameObject playerSpace;
    public GameObject playerInGrav;
    public float rotationSmoothness = 10f;
    public GameObject[] particles;
    public AudioSource engine;
    private bool enginePlaying, isFlying;
    public float maxEngineFuel = 300f, currentEngineFuel;
    public float fuelReduction = 1f;


    //public Thruster thruster;


    public void Awake()
    {
        actionMap = new DefaultActionMap();
        rb = GetComponent<Rigidbody>();
    }

    public void OnEnable()
    {
        interact = actionMap.SpaceShip.Interact;
        move = actionMap.SpaceShip.Move;
        rotation = actionMap.SpaceShip.Rotation;
        upDown = actionMap.SpaceShip.UpDown;
        interact.Enable();
        upDown.Enable();
        rotation.Enable();
        move.Enable();

    }
    public void OnDisable()
    {
        interact.Disable();
        upDown.Disable();
        move.Disable();
        rotation.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentEngineFuel = maxEngineFuel;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > 0.8f)
        {
            if (enginePlaying == false)
            {
                engine.Play();
                enginePlaying = true;
            }
            
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].GetComponent<Thruster>().SetOn(); 
            }
        }
        else
        {
            engine.Stop();
            enginePlaying = false;
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].GetComponent<Thruster>().SetOf();
            }
        }
        
        if(currentEngineFuel != 0)
        {
            MovementShipManager();
            
        }
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
            Vector3 rotateStrenght = new Vector3(0, rotate, 0);
            rb.AddTorque(rotateStrenght * rotationSpeed * Time.deltaTime);
            
        }


        //Up Down
        float upDown = UpDown();
        Vector3 UpDownStrenght = new Vector3(0, -upDown, 0);
        rb.AddForce(UpDownStrenght * thrust * Time.deltaTime);


        EngineFuel();
    }
    public void ExitEnter()
    {
        if (interact.triggered)
        {
            playerSpace.SetActive(true);
            
        }
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
    public float Interact()
    {
        return interact.ReadValue<float>();
    }
    public void EngineFuel()
    {
        DateTime startTime = DateTime.Now;
        if (move.ReadValue<float>() < 0 && currentEngineFuel > 0)
        {
            Debug.Log("Current Fuel" + currentEngineFuel);
            currentEngineFuel -= fuelReduction * Time.deltaTime;
        }
        if (currentEngineFuel < 0)
        {
            currentEngineFuel = 0;
            
        }
    }       
}
