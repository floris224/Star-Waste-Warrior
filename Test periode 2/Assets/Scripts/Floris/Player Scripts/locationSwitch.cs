using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class locationSwitch : MonoBehaviour
{
    public ControllerSwitch controller;
    public GameObject ship, playerSpace, playerGrav;
    public Camera gravCam, shipCam, playerspaceCam;
    public GameObject healthPanel, fuelPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.inShip)
        {
            fuelPanel.SetActive(true);
            healthPanel.SetActive(false);
            shipCam.enabled = true;
            playerspaceCam.enabled = false;
            gravCam.enabled = false;
            playerSpace.SetActive(false);
            playerGrav.SetActive(false);
            ship.GetComponent<SpaceShipMovement>().enabled = true;
        }
        else if (controller.doesPlayerSpaceExist)
        {
            fuelPanel.SetActive(false);
            healthPanel.SetActive(true);
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
            fuelPanel.SetActive(false);
            healthPanel.SetActive(false);
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

