using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractSpaceShip : MonoBehaviour
{
    public GameObject spawnPoint;
    private DefaultActionMap actionmap;
    private InputAction interact;
    public GameObject playerSpace;
    public Camera camSpaceWalk;
    public Camera camSpaceShip;
    private bool outVechicle = false;
    private bool canInteract = true;
    private RaycastHit hit;

    private void Awake()
    {
        actionmap = new DefaultActionMap();
    }

    private void OnEnable()
    {
        interact = actionmap.SpaceShip.Interact;
        interact.Enable();
    }

    private void OnDisable()
    {
        interact.Disable();
    }

    void Update()
    {
        if (!outVechicle)
        {
            if (interact.triggered && canInteract)
            {
                outVechicle = true;
                canInteract = false;
                ExitVehicle();
            }
        }
        else
        {
            if (interact.triggered && canInteract)
            {
                if (Physics.Raycast(playerSpace.transform.position, playerSpace.transform.forward, out hit, 5))
                {
                    if (hit.transform.CompareTag("SpaceShip"))
                    {
                        outVechicle = false;
                        canInteract = false;
                        ReenterVehicle();
                    }
                }
            }
        }

        if (!interact.triggered)
        {
            canInteract = true;
        }
    }

    private void ExitVehicle()
    {
        gameObject.GetComponent<SpaceShipMovement>().enabled = false;
        gameObject.GetComponent<AudioListener>().enabled = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        playerSpace.SetActive(true);
        playerSpace.transform.position = spawnPoint.transform.position;
        for (int i = 0; i < playerSpace.transform.childCount; i++)
        {
            playerSpace.GetComponent<SpaceMovement>().enabled = true;
            playerSpace.transform.GetChild(i).gameObject.SetActive(true);
        }
        camSpaceWalk.GetComponent<Camera>().enabled = true;
        camSpaceShip.GetComponent<Camera>().enabled = false;
        playerSpace.GetComponent<AudioListener>().enabled = true;
        playerSpace.GetComponent<PickupPricker>().enabled = true;
    }

    private void ReenterVehicle()
    {
        // Disable player controls and movement
        playerSpace.GetComponent<SpaceMovement>().enabled = false;
        playerSpace.GetComponent<AudioListener>().enabled = false;
        playerSpace.GetComponent<PickupPricker>().enabled = false;

        // Enable spaceship controls and movement
        gameObject.GetComponent<SpaceShipMovement>().enabled = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<AudioListener>().enabled = true;

        // Set the player position back to the spaceship
        playerSpace.SetActive(false);
        playerSpace.transform.position = spawnPoint.transform.position;

        // Enable spaceship camera and disable player camera
        camSpaceWalk.GetComponent<Camera>().enabled = false;
        camSpaceShip.GetComponent<Camera>().enabled = true;

        // Set all child objects of playerSpace to inactive
        for (int i = 0; i < playerSpace.transform.childCount; i++)
        {
            playerSpace.transform.GetChild(i).gameObject.SetActive(false);
        }

        // Allow interaction again
        canInteract = true;
    }
}
