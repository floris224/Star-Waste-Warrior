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
    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(1, 100);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (random <= 100) 
        {
            if (Vector3.Distance(player.transform.position, transform.position) <= spawnrange)
            {
                Debug.Log("Spawn Alien");
                Instantiate(alien, gameObject.transform.position, gameObject.transform.rotation);
                random = 101;
            }
        }
       
    }
}
