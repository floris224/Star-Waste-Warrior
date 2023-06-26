using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class TeleportGun : MonoBehaviour
{
    public int maxCapacityInventory;
    public int currentCapacity;
    public int maxCapacitySpaceship;
    public string[] tags;
    RaycastHit hit;
    public List<int> inventory = new List<int>();
    public List<int> spaceshipSlots = new List<int>();
    public bool bought;
    public bool weaponEquiped;


    void Update()
    {

        if (bought == true)
        {
            if (weaponEquiped == true)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    if (currentCapacity <= maxCapacityInventory)
                    {
                        if (Physics.Raycast(transform.position, transform.forward, out hit, 100) && tagsMatch(hit.transform.tag))
                        {
                            ValueTrash valueTrash = hit.transform.GetComponent<ValueTrash>();
                            if (valueTrash != null)
                            {
                                inventory.Add(valueTrash.itemValue);
                                currentCapacity += valueTrash.capacity;
                                if (currentCapacity > maxCapacityInventory)
                                {
                                    currentCapacity = maxCapacityInventory;
                                    int money = totalmoney();
                                    spaceshipSlots.Add(money);
                                    inventory.Clear();
                                    if (currentCapacity >= maxCapacitySpaceship)
                                    {
                                        Debug.Log("SpaceShip Full");
                                    }

                                }
                            }

                        }

                    }

                }
            }
        }
    }
    private bool tagsMatch(string tag)
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
    private int totalmoney()
    {
        int totalmoney = 0;
        foreach (int ItemValue in inventory)
        {
            totalmoney += ItemValue;
        }
        return totalmoney;
    }
}
