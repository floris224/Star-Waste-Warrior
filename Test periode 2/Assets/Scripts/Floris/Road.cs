using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Road : MonoBehaviour
{
    public GameObject spaceshipGoToPosition;
    public GameObject spaceship;
    private bool isMoving;
    public float timer;
    public float moveToWardsSpeed;
    public SpaceShipMovement _ship;
    public GameObject playerInGrav;

    private DefaultActionMap actionmap;
    private InputAction interact;

    public Camera camInGrav;
    public Camera camSpaceShip;

    private void Awake()
    {
        actionmap= new DefaultActionMap(); 
    }
    private void OnDisable()
    {
        interact.Disable();
    }
    private void OnEnable()
    {
        interact = actionmap.PlayerSpace.Interact;
        interact.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        timer = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isMoving)
        {
            float step = moveToWardsSpeed * Time.deltaTime;
            spaceship.transform.position = Vector3.MoveTowards(spaceship.transform.position, spaceshipGoToPosition.transform.position, step);
        }

        if (Vector3.Distance(spaceship.transform.position, spaceshipGoToPosition.transform.position) <= 0.01f)
        {
            if (interact.triggered)
            {
                playerInGrav.SetActive(true);
                spaceship.GetComponent<SpaceShipMovement>().enabled = false;
                playerInGrav.GetComponent<MovementinGrav>().enabled = true;
                camSpaceShip.GetComponent<Camera>().enabled = false;
                camInGrav.GetComponent <Camera>().enabled = true;
               
            }
        }


       
        
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpaceShip"))
        {

            other.GetComponent<SpaceShipMovement>().enabled = false;
            spaceship.GetComponent<InteractSpaceShip>().enabled = false;

            isMoving = true;
            Debug.Log("" + other.transform.name);
        }

    }
    float InteractInput()
    {
        return interact.ReadValue<float>();
    }
}
