using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;


public class TeleportGun : MonoBehaviour
{
 
    public int maxCapacityInventory;
    public int currentCapacity, currentCapacitySpaceShip;
    public int maxCapacitySpaceship;
    public string[] tags;
    public int totalMoney, totalMoneySpaceShip;
    public List<int> inventory = new List<int>();
    public List<int> spaceshipSlots = new List<int>();
    public bool bought;
    public bool weaponEquiped;
    public bool shot;
    public Camera playerCam;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public Transform shotPoint;
    public TextMeshProUGUI inventorySlots;
    public Money currentMoney;
    public PickupPricker pickupPricker;



    void Update()
    {
        UpdateUi();


        if (bought == true && weaponEquiped == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentCapacity <= maxCapacityInventory)
                {
                    GameObject bullet = Instantiate(bulletPrefab, shotPoint.transform.position, shotPoint.transform.rotation);
                }
                else if (currentCapacity >= maxCapacityInventory)
                {
                    totalMoneyInventory();
                    spaceshipSlots.Add(totalMoney);
                    inventory.Clear();
                    currentCapacity = 0;
                    UpdateUi();

                    if (currentCapacitySpaceShip >= maxCapacitySpaceship)
                    {
                        currentCapacitySpaceShip = maxCapacitySpaceship;
                        Debug.Log("SpaceShip Full");
                    }
                }
            }
        }
    }
  
    public bool tagsMatch(string tag)
    {
        foreach (string goodtags in tags)
        {
            if (tag == goodtags)
            {
                return true;
            }
        }
        return false;
    }
    public int totalMoneyInventory()
    {
         totalMoney = 0;
        foreach (int ItemValue in inventory)
        {
            totalMoney += ItemValue;
        }
        return totalMoney;
    }
    private int totalMoneyInventorySpaceShip()
    {
        totalMoneySpaceShip = 0;
        foreach (int ItemValue in spaceshipSlots)
        {
            totalMoneySpaceShip += ItemValue;
        }
        return totalMoneySpaceShip;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
   
    public void Sell()
    {
        
        totalMoneyInventory();
        totalMoneyInventorySpaceShip();
        currentMoney.geld += totalMoney + totalMoneySpaceShip;
        UpdateUi();
        spaceshipSlots.Clear();
        inventory.Clear();
 
    }

    private void UpdateUi()
    {
        inventorySlots.text = "Inventory Count:" + currentCapacity + "/" + maxCapacityInventory;
        pickupPricker.UpdateUI();
    }
}
