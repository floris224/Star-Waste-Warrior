using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSwitch : MonoBehaviour
{
    public GameObject spaceShip, playerSpace, playerGrav, spawnPositionPlayer,spawnPositionSpaceStation, healthPanel, fuelPanel;
    public Camera playerSpaceCam, playerGravCam, spaceShipCam;
    public bool inShip, inTrigger,inTriggerSpaceStation;
    public bool doesPlayerSpaceExist;
    public float timeStamp, distance;
    public Collider colliderSpaceShip, colliderSpaceStation;
    public AudioListener audiolist;
    public AudioSource stepInOut;
    // Start is called before the first frame update
    void Start()
    {
       
        //fuelPanel.SetActive(false);
        healthPanel.SetActive(false);
        playerGrav.SetActive(true);
        playerGravCam.enabled = true;
        playerGrav.GetComponent<MovementinGrav>().enabled = true;
        playerSpace.GetComponent<SpaceMovement>().enabled = false;
        playerSpace.SetActive(false);
        doesPlayerSpaceExist = false;
        spaceShip.GetComponent<SpaceShipMovement>().enabled = false;
        spaceShipCam.enabled = false;


    }

    
    private void Update()
    {
        if(Time.time > timeStamp)
        {
            if (inShip == true)
            {
                if (Input.GetKeyDown("f"))
                {
                    if (inTrigger == true)
                    {
                        stepInOut.Play();
                        audiolist.enabled = false;
                        //fuelPanel.SetActive(false);
                        healthPanel.SetActive(false);
                        spaceShipCam.enabled = false;
                        playerGrav.SetActive(true);
                        playerGravCam.enabled = true;
                        playerGrav.GetComponent<MovementinGrav>().enabled = true;
                        spaceShip.GetComponent<SpaceShipMovement>().enabled = false;
                        inShip = false;
                    }
                    else if (inTriggerSpaceStation == true)
                    {
                        playerGrav.transform.position = spawnPositionSpaceStation.transform.position;
                        stepInOut.Play();
                        audiolist.enabled = false;
                        //fuelPanel.SetActive(false);
                        healthPanel.SetActive(false);
                        spaceShipCam.enabled = false;
                        playerGrav.SetActive(true);
                        playerGravCam.enabled = true;
                        playerGrav.GetComponent<MovementinGrav>().enabled = true;
                        spaceShip.GetComponent<SpaceShipMovement>().enabled = false;
                        inShip = false;
                    }
                    else
                    {
                        stepInOut.Play();
                        audiolist.enabled = false;
                        //fuelPanel.SetActive(false);
                        healthPanel.SetActive(true);
                        spaceShipCam.enabled = false;
                        doesPlayerSpaceExist = true;
                        playerSpace.SetActive(true);
                        playerSpaceCam.enabled = true;
                        playerSpace.GetComponent<SpaceMovement>().enabled = true;
                        spaceShip.GetComponent<SpaceShipMovement>().enabled = false;
                        playerSpace.transform.position = spawnPositionPlayer.transform.position;
                        inShip = false;
                    }
                }
            }

        }
        distance = Vector3.Distance(spaceShip.transform.position, transform.position);
        if (distance <= 5)
        {
            inTrigger = true;

        }
        else
        {
            inTrigger = false;
        }
    }
    // Update is called once per frame
    public void SwitchController()
    {
        stepInOut.Play();
        audiolist.enabled = true;
        //fuelPanel.SetActive(true);
        healthPanel.SetActive(false);
        timeStamp = Time.time + 3f;
        inShip = true;
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
