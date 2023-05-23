using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public int random;
    public GameObject alien;
    public float spawnrange;
    public GameObject player;
    public float distance;
    public GameObject rumblingSFX;
    public bool sound;
    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(1, 100);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (random <= 100) 
        {
            if (sound == false)
            {
                Instantiate(rumblingSFX, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
                sound = true;
            }
            
            if (distance <= spawnrange)
            {
                Debug.Log("Spawn Alien");
                Instantiate(alien, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(GetComponent<Transform>().GetChild(1).gameObject);
                random = 101;
            }
        }
       
    }
}
