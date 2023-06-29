using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPShot : MonoBehaviour
{
    public float bulletspeed;
    public GameObject explosion, hitTrash;
    public float timeStamp;
    // Start is called before the first frame update
    void Start()
    {
        
        gameObject.GetComponent<Rigidbody>().velocity   = gameObject.transform.forward * bulletspeed *Time.deltaTime;
        timeStamp = Time.time + 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStamp < Time.time)
        {
            Destroy(gameObject);
            Debug.Log(" shot");
        }   
    }
    public void OnCollisionEnter(Collision collision)
    {
        TeleportGun teleportGun = FindObjectOfType<TeleportGun>();
        if (teleportGun.tagsMatch(collision.transform.tag))
        {
            Instantiate(hitTrash, transform.position, transform.rotation);
        }
        else
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
