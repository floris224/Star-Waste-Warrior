using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletCollider : MonoBehaviour
{
    public ParticleSystem explosion;

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
            }

            if (teleportGun.tagsMatch(collision.transform.tag))
            {
                Destroy(gameObject);
                ParticleSystem explosionPrefab = Instantiate(explosion, collision.transform.position, Quaternion.identity);
                
            }

            if (teleportGun.tagsMatch(collision.transform.tag))
            {
                Destroy(collision.transform.gameObject);
            }
           
        }
    }
}