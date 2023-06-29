using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public List<GameObject> weapons;
    private int currentWeaponIndex = 0;
    public TeleportGun teleportGun;
    public GameObject laserGun;
   
    // Update is called once per frame
    void Update()
    {
        teleportGun = laserGun.GetComponent<TeleportGun>();
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput > 0f) // Scroll wheel up
        {
            ChangeWeapon(1);
        }
        else if (scrollInput < 0f) // Scroll wheel down
        {
            ChangeWeapon(-1);
        }
    }
    void ChangeWeapon(int index)
    {
        weapons[currentWeaponIndex].SetActive(false);
        currentWeaponIndex += index;
        if(currentWeaponIndex < 0)
        {
            currentWeaponIndex = weapons.Count - 1;
        }
        else if ( currentWeaponIndex >= weapons.Count)
        {
            currentWeaponIndex = 0;
        }
        weapons[currentWeaponIndex].SetActive(true);
        
        if (weapons[currentWeaponIndex].TryGetComponent(out teleportGun))
        {
            teleportGun.enabled = true;
            teleportGun.weaponEquiped = true;
        }
        else
        {
            if (teleportGun != null)
                teleportGun.enabled = false;
        }
    }  


}
