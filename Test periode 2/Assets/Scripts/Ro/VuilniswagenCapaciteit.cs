using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VuilniswagenCapaciteit : MonoBehaviour
{
    public int capaciteit;
    public int maxCapacitySpaceShip, currentCapacitySpaceShip;
    public int totalMoney;
    public GameObject[] trash;
    public List<int> spaceshipSlots = new List<int>();
    public List<int> playerInventory = new List<int>();
    
    public PickupPricker pickUpPrikker;
    // Start is called before the first frame update
    void Start()
    {
        pickUpPrikker = GetComponent<PickupPricker>();
        
        playerInventory = pickUpPrikker.capaciteitList;
        currentCapacitySpaceShip = spaceshipSlots.Count;
        maxCapacitySpaceShip = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (capaciteit < 1)
        {
            for (int i = 0; i < trash.Length; i++)
            {
                trash[i].SetActive(false);
            }
        }
        if (capaciteit >= 1 && capaciteit < 5)
        {
            trash[0].SetActive(true);
            for (int i = 1; i < trash.Length; i++)
            {
                trash[i].SetActive(false);
            }
        }
        if (capaciteit >= 5 && capaciteit < 10)
        {
            trash[0].SetActive(true);
            trash[1].SetActive(true);
            for (int i = 2; i < trash.Length; i++)
            {
                trash[i].SetActive(false);
            }
        }
        if (capaciteit >= 10 && capaciteit < 15)
        {
            trash[0].SetActive(true);
            trash[1].SetActive(true);
            trash[2].SetActive(true);
            for (int i = 3; i < trash.Length; i++)
            {
                trash[i].SetActive(false);
            }
        }
    }

    public void PutTrashInTruck()
    {
        totalMoneyInventory();
        Debug.Log(totalMoneyInventory());
       
        if(currentCapacitySpaceShip > maxCapacitySpaceShip)
        {
            currentCapacitySpaceShip = maxCapacitySpaceShip;
            Debug.Log("inventoryFull");
        }
        else
        {
            spaceshipSlots.Add(totalMoney);
            pickUpPrikker.capaciteitList.Clear();
            
        }
    }

    public int totalMoneyInventory()
    {
        totalMoney = 0;
        foreach (int ItemValue in pickUpPrikker.capaciteitList)
        {
            totalMoney += ItemValue;
        }
        return totalMoney;
    }
}
