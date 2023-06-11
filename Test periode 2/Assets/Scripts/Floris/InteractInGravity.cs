using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractInGravity : MonoBehaviour
{
    private DefaultActionMap actionMap;
    private InputAction enter;
    public RaycastHit hit;
    public GameObject playerInGrav;
    public GameObject playerInGravCam;
    public Camera spaceShipCam;
    public GameObject spaceShip;
    public InteractSpaceShip spaceshipScript;
    public SpaceShipMovement _ship;
    public InteractSpaceShip _interact;
    private void Awake()
    {
        actionMap = new DefaultActionMap();
    }

    private void OnEnable()
    {
        enter = actionMap.PlayerInForcefield.Interact;
        enter.Enable();
    }

    private void OnDisable()
    {
        enter.Disable();
    }
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enter.triggered)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 5f))
            {
                if (hit.transform.CompareTag("SpaceShip"))
                {
                    _ship.enabled = true;
                    _interact.enabled = true;
                    playerInGrav.SetActive(false);
                    playerInGrav.GetComponent<MovementinGrav>().enabled = false;
                    playerInGrav.GetComponent<InteractInGrav>().enabled = false;
                    spaceShipCam.enabled = true;
                    playerInGravCam.SetActive(false);

                    
                }
               

            }
        }
    }
}
