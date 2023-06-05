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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enter.triggered)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 5f))
            {
                if (hit.rigidbody.CompareTag("SpaceShip"))
                {
                    playerInGrav.SetActive(false);
                    playerInGrav.GetComponent<MovementinGrav>().enabled = false;
                    spaceShip.GetComponent<SpaceShipMovement>().enabled = true;
                    spaceShipCam.enabled = true;
                    playerInGravCam.SetActive(false);


                }

            }
        }
    }
}
