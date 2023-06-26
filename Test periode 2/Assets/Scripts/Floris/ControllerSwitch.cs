using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSwitch : MonoBehaviour
{
    public GameObject spaceShip, playerSpace, playerGrav, spawnPositionPlayer;
    public Camera playerSpaceCam, playerGravCam, spaceShipCam;
    public bool inShip, inTrigger;
    public bool doesPlayerSpaceExist;
    public float timeStamp, distance;
    public Collider colliderSpaceShip;
    
    // Start is called before the first frame update
    void Start()
    {
        //playerGrav.SetActive(true);
        playerGravCam.enabled = true;
        playerGrav.GetComponent<MovementinGrav>().enabled = true;
        playerSpace.GetComponent<SpaceMovement>().enabled = false;
        //playerSpace.SetActive(false);
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
                        spaceShipCam.enabled = false;
                        playerGrav.SetActive(true);
                        playerGravCam.enabled = true;
                        playerGrav.GetComponent<MovementinGrav>().enabled = true;
                        spaceShip.GetComponent<SpaceShipMovement>().enabled = false;
                        inShip = false;
                    }
                    else
                    {
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
