using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementswitch : MonoBehaviour
{
    public Collider player;
    public GameObject player1, player2, empty, charac;
    public bool ingrav;
    public MeshRenderer character;
    //public Movement movement;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (ingrav == true)
        {
            //movement.enabled = false;
            player.isTrigger = true;
            player1.transform.position = player2.transform.position;
            player1.transform.rotation = player2.transform.rotation;
            player1.GetComponent<Rigidbody>().freezeRotation = true;
        }
        else
        {
            //movement.enabled = true;
            player.isTrigger = false;
            player2.transform.position = player1.transform.position;
            player1.GetComponent<Rigidbody>().freezeRotation = false;
        }
    }
    public void OnTriggerEnter(Collider player)
    {
        if (player.transform.tag == "Gravity")
        {
            charac.transform.position += new Vector3(0, -1, 0);
        }
    }
    public void OnTriggerStay(Collider player)
    {
        if (player.transform.tag == "Gravity")
        {
            ingrav = true;
            Debug.Log("gravity");
            empty.SetActive(false);
            player2.SetActive(true);
            character.enabled = false;
        }
        else
        {
            print("ingrav uit");
            ingrav = false;
            empty.SetActive(true);
            player2.SetActive(false);
            character.enabled = true;
        }
    }
}
