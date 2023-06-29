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
   
    public List<int> inventory = new List<int>();
    public List<int> spaceshipSlots = new List<int>();
    public bool bought;
    public bool weaponEquiped;
    public Camera playerCam;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public Transform shotPoint;



    void Update()
    {
        if (bought == true && weaponEquiped == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentCapacity < maxCapacityInventory)
                {
                    
                    GameObject bullet = Instantiate(bulletPrefab, shotPoint.transform.position, shotPoint.transform.rotation);

                    Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                    bulletRigidbody.velocity = bullet.transform.forward * bulletSpeed* Time.deltaTime;
                    
                   

                    if (currentCapacity >= maxCapacityInventory)
                    {
                        currentCapacity = maxCapacityInventory;
                        int money = totalMoney();
                        spaceshipSlots.Add(money);
                        inventory.Clear();
                        if (currentCapacity >= maxCapacitySpaceship)
                        {
                            currentCapacity = maxCapacitySpaceship;
                            Debug.Log("SpaceShip Full");
                        }
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
    private int totalMoney()
    {
        int totalmoney = 0;
        foreach (int ItemValue in inventory)
        {
            totalmoney += ItemValue;
        }
        return totalmoney;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
