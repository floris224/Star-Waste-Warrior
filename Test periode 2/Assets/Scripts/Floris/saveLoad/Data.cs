using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using UnityEngine;

public class Data : MonoBehaviour
{
    public ShopManager shopManager;
    public TeleportGun teleportGun;
    public GameObject playerInSpace;
    public GameObject playerInGrav;
    public bool _inship, _inspace, _ingrav, hasBoughtGun, hasBoughtTeleportGun, hasBoughtFuelUpgrade, hasBought;
    public bool  hasBoughtBoosters, hasBoughtRope, hasBoughtTruckBack, hasBoughtTruckFront;
    public Transform[] pos;
    public float[] inshipLoc;
    public float[] inspaceLoc;
    public float[] ingravLoc;
   
    public float playerHealth;
    public float playerMoney;

    public ControllerSwitch _controllerSwitch;
    // Start is called before the first frame update
    public void Start()
    {
        SaveLoadData data = SaveLoad.LoadData();
        _inspace = data._inspace;
        _inship = data._inship;
        _ingrav = data._ingrav;
        playerHealth = data.playerHealth;
        playerMoney = data.playerMoney;
       
        hasBought = data.hasBought;
        hasBoughtBoosters = data.hasBoughtBoosters;
        hasBoughtRope = data.hasBoughtRope;
        hasBoughtTruckBack = data.hasBoughtTruckBack;
        hasBoughtTruckFront = data.hasBoughtTruckFront;
        hasBoughtGun = data.hasBoughtGun;

        inshipLoc[0] = data.shipPos1;
        inshipLoc[1] = data.shipPos2;
        inshipLoc[2] = data.shipPos3;
        Vector3 shiplocation = new Vector3(inshipLoc[0], inshipLoc[1], inshipLoc[2]);
        pos[0].position = shiplocation;



        ingravLoc[0] = data.gravPos1;
        ingravLoc[1] = data.gravPos2;
        ingravLoc[2] = data.gravPos3;
        Vector3 gravPos = new Vector3(ingravLoc[0], ingravLoc[1], ingravLoc[2]);
        pos[2].position = gravPos;


        inspaceLoc[0] = data.spacePos1;
        inspaceLoc[1] = data.spacePos2;
        inspaceLoc[2] = data.spacePos3;
        Vector3 spacePos = new Vector3(inspaceLoc[0], inspaceLoc[1], inspaceLoc[2]);
        pos[1].position = spacePos;


       

        _controllerSwitch.inShip = _inship;
        _controllerSwitch.doesPlayerSpaceExist = _inspace;
        _controllerSwitch.inTrigger = _ingrav;
    }

    public void Update()
    {
        playerHealth = playerInSpace.GetComponent<PlayerHealth>().health;
        playerMoney = playerInGrav.GetComponent<Money>().geld;
        hasBought = teleportGun.bought;
    }


    public void Save()
    {
        _inship = _controllerSwitch.inShip;
        _inspace = _controllerSwitch.doesPlayerSpaceExist;
        _ingrav = _controllerSwitch.inTrigger;

        hasBoughtGun = shopManager.hasBoughtGun;
        hasBought = teleportGun.bought;
        hasBoughtBoosters = shopManager.hasBoughtBoosters;
        hasBoughtRope = shopManager.hasBoughtRope;
        hasBoughtTruckBack = shopManager.hasBoughtTruckBack;
        hasBoughtTruckFront = shopManager.hasBoughtTruckFront;

        playerHealth = playerInSpace.GetComponent<PlayerHealth>().health;
        playerMoney = playerInGrav.GetComponent<Money>().geld;
        inshipLoc[0] = pos[0].position.x;
        inshipLoc[1] = pos[0].position.y;
        inshipLoc[2] = pos[0].position.z;

        inspaceLoc[0] = pos[1].position.x;
        inspaceLoc[1] = pos[1].position.y;
        inspaceLoc[2] = pos[1].position.z;

        ingravLoc[0] = pos[2].position.x;
        ingravLoc[1] = pos[2].position.y;
        ingravLoc[2] = pos[2].position.z;
        SaveLoad.SaveData(this);
    }
}
