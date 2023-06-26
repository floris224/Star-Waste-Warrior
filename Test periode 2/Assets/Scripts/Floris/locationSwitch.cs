using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locationSwitch : MonoBehaviour
{
    public ControllerSwitch controller;
    public GameObject ship, playerSpace, playerGrav;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.inShip == true)
        {
            ship.SetActive(true);
            playerGrav.SetActive(false);
            playerSpace.SetActive(false);
        }
        if (controller.playerSpace == true)
        {
            playerSpace.SetActive(true);
            ship.SetActive(false);
            playerGrav.SetActive(false);
        }
        if (controller.playerGrav == true)
        {
            playerGrav.SetActive(true);
            ship.SetActive(false);
            playerSpace.SetActive(false);
        }
    }
}
