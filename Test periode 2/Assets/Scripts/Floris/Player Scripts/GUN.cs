using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;


public class GUN : MonoBehaviour
{
    public  RaycastHit hit;
    public GameObject shotPoint;
    public int gunDamage;
    public bool hasBought, hasEquipped;
    // Start is called before the first frame update
    void Start()
    {
        hasBought = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot(100f);
            
           

        }
    }
    void Shoot(float range)
    {
        if(hasBought == true)
        {
            if (Physics.Raycast(shotPoint.transform.position, shotPoint.transform.forward, out hit, range))
            {

                Alien enemy = hit.transform.GetComponent<Alien>();
                UFO ufo = hit.transform.GetComponent<UFO>();
                if (enemy != null)
                {
                    enemy.ahealth -= gunDamage;
                    ufo.ufoHealth -= gunDamage;

                }

            }
        }
        
    }
   
}
