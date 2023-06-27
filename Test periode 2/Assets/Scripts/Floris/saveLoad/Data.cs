using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using UnityEngine;

public class Data : MonoBehaviour
{
    public bool _inship, _inspace, _ingrav;
    public Transform[] pos;
    public float[] inshipLoc;
    public float[] inspaceLoc;
    public float[] ingravloc;

    public ControllerSwitch _controllerSwitch;
    // Start is called before the first frame update
    public void Start()
    {
        SaveLoadData data = SaveLoad.LoadData();
        _inspace = data._inspace;
        _inship = data._inship;
        _ingrav = data._ingrav;

        inshipLoc[0] = data.shipPos1;
        inshipLoc[1] = data.shipPos2;
        inshipLoc[2] = data.shipPos3;
        Vector3 shiplocation = new Vector3(inshipLoc[0], inshipLoc[1], inshipLoc[2]);
        pos[0].position = shiplocation;



        ingravloc[0] = data.gravPos1;
        ingravloc[1] = data.gravPos2;
        ingravloc[2] = data.gravPos3;
        Vector3 gravPos = new Vector3(ingravloc[0], ingravloc[1], ingravloc[2]);
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

     void Update()
    {
       
    }


    public void Save() 
    {
        _inship = _controllerSwitch.inShip;
        _inspace = _controllerSwitch.doesPlayerSpaceExist;
        _ingrav = _controllerSwitch.inTrigger;

        inshipLoc[0] = pos[0].position.x;
        inshipLoc[1] = pos[0].position.y;
        inshipLoc[2] = pos[0].position.z;

        inspaceLoc[0] = pos[1].position.x;
        inspaceLoc[1] = pos[1].position.y;
        inspaceLoc[2] = pos[1].position.z;

        ingravloc[0] = pos[2].position.x;
        ingravloc[1] = pos[2].position.y;
        ingravloc[2] = pos[2].position.z;
        SaveLoad.SaveData(this);
    }
}
