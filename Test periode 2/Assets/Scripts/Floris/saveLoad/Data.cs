using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using UnityEngine;

[System.Serializable]
public class Data : MonoBehaviour
{
    public Money money;
    public ShopManager shopManager;
    public TeleportGun teleportGun;
    public GameObject playerInSpace;
    public GameObject playerInGrav;
    public GameObject spaceShip;
    public bool _inship, _inspace, _ingrav, hasBoughtTeleportGun, hasBoughtFuelUpgrade, hasBought;
    public bool  hasBoughtBoosters, hasBoughtRope, hasBoughtTruckBack, hasBoughtTruckFront;
    public Transform[] pos;
    public float[] inshipLoc = new float[3];
    public float[] inspaceLoc = new float[3];
    public float[] ingravLoc = new float[3];
   
    public float playerHealth;
    public int playerMoney;

    public float fuel;
    public float currentEngineFuel;

    public ControllerSwitch _controllerSwitch;

    
    private void Awake()
    {
        

    }
    // Start is called before the first frame update
    public void Start()
    {
       
        SaveLoadData data = SaveLoad.LoadData();
        if(data != null)
        {
            _inspace = data._inspace;
            _inship = data._inship;
            _ingrav = data._ingrav;

            playerMoney = data.playerMoney;
            money.SetMoney(playerMoney);

            fuel = data.fuel;
            spaceShip.GetComponent<SpaceShipMovement>().currentEngineFuel = fuel;
            playerHealth = data.playerHealth;
            playerInSpace.AddComponent<PlayerHealth>().health = playerHealth;

            hasBought = data.hasBought;
            hasBoughtTeleportGun = data.hasBoughtTeleportGun;
            hasBoughtBoosters = data.hasBoughtBoosters;
            hasBoughtFuelUpgrade = data.hasBoughtFuelUpgrade;
            hasBoughtRope = data.hasBoughtRope;
            hasBoughtTruckBack = data.hasBoughtTruckBack;
            hasBoughtTruckFront = data.hasBoughtTruckFront;

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
        else
        {
            playerMoney = 0;
            money.SetMoney(playerMoney);
        }

        Debug.Log("playerMoney value after loading: " + playerMoney);
    }

    public void Update()
    {
  
    }


    public void Save()
    {
        Debug.Log("Before loading: " + playerMoney);
        _inship = _controllerSwitch.inShip;
        _inspace = _controllerSwitch.doesPlayerSpaceExist;
        _ingrav = _controllerSwitch.inTrigger;
        
        hasBought = shopManager.hasBoughtGun;
        hasBoughtTeleportGun = shopManager.TeleportGun.bought;
        hasBoughtBoosters = shopManager.hasBoughtBoosters;
        hasBoughtFuelUpgrade = shopManager.hasBoughtFuelUpgrade;
        hasBoughtRope = shopManager.hasBoughtRope;
        hasBoughtTruckBack =shopManager.hasBoughtTruckBack;
        hasBoughtTruckFront = shopManager.hasBoughtTruckFront;

        fuel = spaceShip.GetComponent<SpaceShipMovement>().currentEngineFuel;


        playerMoney = money.GetMoney();
        playerHealth = playerInSpace.GetComponent<PlayerHealth>().health;
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
