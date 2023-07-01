using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locationSwitch : MonoBehaviour
{
    public ControllerSwitch controller;
    public GameObject ship, playerSpace, playerGrav;
    public Camera gravCam, shipCam, playerspaceCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.inShip)
        {
            shipCam.enabled = true;
            playerspaceCam.enabled = false;
            gravCam.enabled = false;
            playerSpace.SetActive(false);
            playerGrav.SetActive(false);
            ship.GetComponent<SpaceShipMovement>().enabled = true;
        }
        else if (controller.doesPlayerSpaceExist)
        {
            shipCam.enabled = false;
            playerspaceCam.enabled = true;
            gravCam.enabled = false;
            playerSpace.SetActive(true);
            playerGrav.SetActive(false);
            playerSpace.GetComponent<SpaceMovement>().enabled = true;
            ship.GetComponent<SpaceShipMovement>().enabled = false;
        }
        else if (controller.inTrigger)
        {
            shipCam.enabled = false;
            playerspaceCam.enabled = false;
            gravCam.enabled = true;
            playerSpace.SetActive(false);
            playerGrav.SetActive(true);
            playerGrav.GetComponent<MovementinGrav>().enabled = true;
            ship.GetComponent<SpaceShipMovement>().enabled = false;
        }
    }
}

