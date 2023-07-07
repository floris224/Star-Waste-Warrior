using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public List<GameObject> weapons;
    private int currentWeaponIndex = 0;
    public TeleportGun teleportGun;
    public GameObject laserGun;
    public GUN gun;
    
    private ShopManager shopManager;

    // Start is called before the first frame update
    void Start()
    {
        
        shopManager = FindObjectOfType<ShopManager>();
    }

    // Update is called once per frame
    void Update()
    {
        teleportGun = laserGun.GetComponent<TeleportGun>();
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput > 0f)
        {
            ChangeWeapon(1);
        }
        else if (scrollInput < 0f)
        {
            ChangeWeapon(-1);
        }
    }

    void ChangeWeapon(int index)
    {
        

        weapons[currentWeaponIndex].SetActive(false);
        currentWeaponIndex += index;

        if (currentWeaponIndex < 0)
        {
            currentWeaponIndex = weapons.Count - 1;
        }
        else if (currentWeaponIndex >= weapons.Count)
        {
            currentWeaponIndex = 0;
        }
        weapons[currentWeaponIndex].SetActive(true);

        
       
            if (weapons[currentWeaponIndex].TryGetComponent(out teleportGun))
            {
                teleportGun.enabled = true;
                teleportGun.weaponEquiped = true;
            }
            else if (teleportGun != null)
            {
                teleportGun.enabled = false;
            }
            else if (weapons[currentWeaponIndex].TryGetComponent(out gun))
            {
                gun.enabled = true;
                gun.hasEquipped = true;
            }
            else if (gun != null)
            {
                gun.hasBought = true;
                gun.hasEquipped = false;
            }
        
       
        
            if (teleportGun != null)
            {
                teleportGun.enabled = false;
                teleportGun.weaponEquiped = false;
            }
            if (gun != null)
            {
                gun.hasBought = true;
                gun.hasEquipped = false;
            }
        
    }

    
    
}