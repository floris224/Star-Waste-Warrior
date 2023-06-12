using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSwitch : MonoBehaviour
{
    public GameObject spaceShip, playerSpace, playerGrav;
    public Camera playerSpaceCam, playerGravCam, spaceShipCam;
    public bool inShip, inTrigger;
    public bool doesPlayerSpaceExist;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Update()
    {
        if (inShip == true)
        {
            if (Input.GetKeyDown("f"))
            {
                if (inTrigger == true)
                {
                    spaceShipCam.enabled = false;
                    playerGrav.SetActive(true);
                    playerGravCam.enabled = true;
                    playerGrav.GetComponent<MovementinGrav>().enabled = true;
                    spaceShip.GetComponent<SpaceShipMovement>().enabled = false;
                }
                else
                {
                    spaceShipCam.enabled = false;
                    doesPlayerSpaceExist = true;
                    playerSpace.SetActive(true);
                    playerSpaceCam.enabled = true;
                    playerSpace.GetComponent<SpaceMovement>().enabled = true;
                    spaceShip.GetComponent<SpaceShipMovement>().enabled = false;
                }
            }
        }
    }
    // Update is called once per frame
    public void SwitchController()
    {
        if (inShip == false)
        {
            spaceShipCam.enabled = true;
            playerSpace.SetActive(false);
            playerSpaceCam.enabled = false;
            doesPlayerSpaceExist = false;
            playerGrav.SetActive(false);
            playerGravCam.enabled = false;
            playerGrav.GetComponent<MovementinGrav>().enabled = false;
            playerSpace.GetComponent<SpaceMovement>().enabled = false;
            spaceShip.GetComponent<SpaceShipMovement>().enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("SpaceShip"))
        {
            inTrigger = true;
        }
        else
        {
            inTrigger = false;
        }
    }
}
