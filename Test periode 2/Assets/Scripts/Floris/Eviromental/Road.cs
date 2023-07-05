using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Road : MonoBehaviour
{
    public ControllerSwitch _switch;
    public GameObject spaceshipGoToPosition;
    public GameObject spaceship;
    public bool hasRotated;
    public bool isMoving;
    public float timer;
    public float moveToWardsSpeed;
    
    public GameObject playerInGrav;
    public GameObject player;

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
        interact = actionmap.SpaceShip.Interact;
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

            if (Vector3.Distance(spaceship.transform.position, spaceshipGoToPosition.transform.position) <= 1)
            {
                Quaternion targetRotation = Quaternion.LookRotation(spaceshipGoToPosition.transform.position - spaceship.transform.position, Vector3.up);

                spaceship.transform.rotation = targetRotation;
                isMoving = false;
                
            }
           

        }

        
        




    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpaceShip"))
        {

           
            isMoving = true;
           
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
       _switch.inTrigger = false;
    }

    private float Interact()
    {
        return interact.ReadValue<float>();
    }
}
