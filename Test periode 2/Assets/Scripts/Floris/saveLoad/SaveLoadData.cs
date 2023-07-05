using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SaveLoadData
{
    //fuel

    public float spacePos1, spacePos2, spacePos3;
    public float gravPos1, gravPos2, gravPos3;
    public float shipPos1, shipPos2, shipPos3;
    public float playerHealth, playerMoney;
    public bool _inship, _inspace, _ingrav, hasBought, hasBoughtGun, hasBoughtBoosters, hasBoughtRope, hasBoughtTruckBack, hasBoughtTruckFront;

    public SaveLoadData(Data data)
    {
        _inship = data._inship;
        _inspace = data._inspace;
        _ingrav = data._ingrav;

        spacePos1 = data.inspaceLoc[0];
        spacePos2 = data.inspaceLoc[1];
        spacePos3 = data.inspaceLoc[2];

        gravPos1 = data.ingravLoc[0];
        gravPos2 = data.ingravLoc[1];
        gravPos3 = data.ingravLoc[2];

        shipPos1 = data.inshipLoc[0];
        shipPos2 = data.inshipLoc[1];
        shipPos3 = data.inshipLoc[2];

        hasBoughtGun = data.hasBoughtGun;
        playerHealth = data.playerHealth;
        playerMoney = data.playerMoney;
        hasBought = data.hasBought;
        hasBoughtBoosters = data.hasBoughtBoosters;
        hasBoughtRope = data.hasBoughtRope;
        hasBoughtTruckBack = data.hasBoughtTruckBack;
    }
}

