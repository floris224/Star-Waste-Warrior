using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Road : MonoBehaviour
{
    public GameObject spaceshipGoToPosition;
    public GameObject spaceship;
    public bool hasRotated;
    private bool isMoving;
    public float timer;
    public float moveToWardsSpeed;
    
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isMoving)
        {

            float step = moveToWardsSpeed * Time.deltaTime;
            spaceship.transform.position = Vector3.MoveTowards(spaceship.transform.position, spaceshipGoToPosition.transform.position, step);

            if (!hasRotated && Vector3.Distance(spaceship.transform.position, spaceshipGoToPosition.transform.position) <= 0.01f)
            {
                // Calculate the target rotation
                Quaternion targetRotation = Quaternion.LookRotation(spaceshipGoToPosition.transform.position - spaceship.transform.position, Vector3.up);

                // Set the rotation directly
                spaceship.transform.rotation = targetRotation;

                hasRotated = true; // Set the flag to true to prevent further rotation
                isMoving = false;
            }

        }

        if (Vector3.Distance(spaceship.transform.position, spaceshipGoToPosition.transform.position) <= 1f)
        {
            if (interact.triggered)
            {
                playerInGrav.SetActive(true);
                
                playerInGrav.GetComponent<MovementinGrav>().enabled = true;
                camSpaceShip.GetComponent<Camera>().enabled = false;
                camInGrav.GetComponent <Camera>().enabled = true;
               

            }
        }

        if (Vector3.Distance(spaceship.transform.position, spaceshipGoToPosition.transform.position) >= 5f)
        {
            spaceship.GetComponent<InteractSpaceShip>().enabled = true;
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
