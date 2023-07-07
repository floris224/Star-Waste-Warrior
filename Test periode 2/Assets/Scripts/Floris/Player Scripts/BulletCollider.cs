using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletCollider : MonoBehaviour
{
    public GameObject hitTrash;
    public bool exploded;
    public VuilniswagenCapaciteit capaciteit;

    public void Awake()
    {
        capaciteit = FindObjectOfType<VuilniswagenCapaciteit>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        
        
        ValueTrash valueTrash = collision.transform.GetComponent<ValueTrash>();
        if (valueTrash != null)
        {
            TeleportGun teleportGun = FindObjectOfType<TeleportGun>();
            if (teleportGun != null)
            {
                teleportGun.inventory.Add(valueTrash.itemValue);
                teleportGun.currentCapacity += valueTrash.capacity;

                teleportGun.currentCapacitySpaceShip = capaciteit.spaceshipSlots.Count;
            }

            

            if (teleportGun.tagsMatch(collision.transform.tag))
            {
                Destroy(collision.transform.gameObject);
            }
           
        }
    }
}