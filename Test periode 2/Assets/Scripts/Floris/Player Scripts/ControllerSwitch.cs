using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

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
    public RaycastHit hit;
    public Transform spawnPointGrav;
    public Transform spawnPos;
    // Start is called before the first frame update
    void Start()
    {
       
        fuelPanel.SetActive(false);
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
        ExitSpaceStation();
        if(Time.time > timeStamp)
        {
            if (inShip == true)
            {
                if (Input.GetKeyDown("f")) // player in grav
                {
                    if (inTrigger == true)
                    {
                        stepInOut.Play();
                        audiolist.enabled = false;
                        fuelPanel.SetActive(false);
                        healthPanel.SetActive(false);
                        spaceShipCam.enabled = false;
                        playerGrav.SetActive(true);
                        playerGrav.transform.position = spawnPointGrav.transform.position;
                        playerGravCam.enabled = true;
                        playerGrav.GetComponent<MovementinGrav>().enabled = true;
                        spaceShip.GetComponent<SpaceShipMovement>().enabled = false;
                        inShip = false;
                    }
                    else if (inTriggerSpaceStation == true) // player in spacestation
                    {
                        playerGrav.transform.position = spawnPositionSpaceStation.transform.position;
                        stepInOut.Play();
                        audiolist.enabled = false;
                        fuelPanel.SetActive(false);
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
                        fuelPanel.SetActive(false);
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
        fuelPanel.SetActive(true);
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
    public void ExitSpaceStation()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Physics.Raycast(playerGravCam.transform.position, playerGravCam.transform.forward, out hit, 10f))
            {
                if (hit.transform.CompareTag("ExitSpaceStation"))
                {
                    stepInOut.Play();
                    audiolist.enabled = true;
                    fuelPanel.SetActive(true);
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
        }
    }
    

   
}


