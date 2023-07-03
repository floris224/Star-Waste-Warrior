using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractInGrav : MonoBehaviour
{
    private DefaultActionMap actionMap;
    private InputAction enter;
    public RaycastHit hit;
    public GameObject playerInGrav;
    public Camera playerInGravCam;
    public Camera spaceShipCam;
    public GameObject spaceShip;

    // Start is called before the first frame update
    private void Awake()
    {
        actionMap = new DefaultActionMap();

    }
    private void OnEnable()
    {
        InputAction interact = actionMap.PlayerInForcefield.Interact;
        enter = interact;
        enter.Enable();

    }
    private void OnDisable()
    {
        enter.Disable();
    }


    void Update()
    {
        if (enter.triggered)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 5f))
            {
                if( hit.transform.name == "SpaceShip")
                {
                    spaceShipCam.GetComponent<Camera>().enabled = true;
                    playerInGravCam.GetComponent<Camera>().enabled = false;
                    playerInGrav.SetActive(false);
                    playerInGrav.GetComponent<MovementinGrav>().enabled = false;
                    spaceShip.GetComponent<SpaceShipMovement>().enabled = true;



                }
               
               
                
                


            }
        }
    }

    private float interacting()
    {
        return enter.ReadValue<float>();
    }
}
