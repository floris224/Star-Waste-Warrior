using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject vrachtwagen;
    public GameObject player;
    public GameObject stoel;
    public RaycastHit hitt;
    public Camera pCam;
    public Camera vCam;
    public MT mt;
    public GameObject hand;
    
    public Vector3 carPos;

    public bool inCar;
    public MeshRenderer pInvis;
    public MeshRenderer sInvis;

    public Pay pay;



    // Start is called before the first frame update
    void Start()
    {
       pInvis = player.GetComponent<MeshRenderer>();
       sInvis = stoel.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       enterCar();
       exitCar();
        
        
      
    }
    public void enterCar()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (Physics.Raycast(gameObject.transform.position, transform.forward, out hitt, 5f))
            {
                if (hitt.rigidbody.CompareTag("Car"))
                {
                    vCam.enabled = true;
                    pCam.enabled = false;
                    pInvis.enabled = false;
                    sInvis.enabled = false;
                    mt.enabled = true;
                    carPos = hitt.rigidbody.transform.position;
                    inCar = true;
                }

                

            }


        }
    }
    public void exitCar()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(inCar == true)
            {
                player.transform.position = carPos + new Vector3(2, 0, 0);
                pInvis.enabled = true;
                sInvis.enabled = true;
                mt.enabled = false;
                pCam.enabled = true;
                vCam.enabled = false;
                inCar =false;
                Debug.Log("test");
            }
        }
    }
    public void pickUp()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (Physics.Raycast(gameObject.transform.position, transform.forward, out hitt, 5f))
            {
                if(hitt.rigidbody.name == "Boosters")
                {
                    pay.inBasket();
                }
            }
        }
    }
}
