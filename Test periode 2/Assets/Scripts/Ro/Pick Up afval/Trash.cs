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
    public ControllerSwitch controllerSwitch;
    // Start is called before the first frame update
    private void Awake()
    {
        controllerSwitch = GameObject.Find("Road").GetComponent<ControllerSwitch>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        random = Random.Range(1, 100);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controllerSwitch.doesPlayerSpaceExist == true)
        {
            distance = Vector3.Distance(player.transform.position, transform.position);
        }
        else
        {
            distance = 8;
        }
       
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
                Destroy(gameObject.transform.Find("Rumbling(Clone)").gameObject);
                random = 101;
            }
        }
       
    }
}
