using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InTriggerSpaceStation : MonoBehaviour
{
    public ControllerSwitch controlSwitch;
    public GameObject playerinGrav;
    public GameObject spawnPointSpacestation;
    public GameObject spaceShip;
    public Camera shipCam, gravCam;
    public bool inShip;
    private void Start()
    {
       
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.transform.CompareTag("SpaceShip"))
        {
            controlSwitch.inTriggerSpaceStation = true;
            
        }
        else
        {
            controlSwitch.inTriggerSpaceStation = false;
        }
    }
}
