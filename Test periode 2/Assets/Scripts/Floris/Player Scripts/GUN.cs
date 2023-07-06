using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;


public class GUN : MonoBehaviour
{
    public  RaycastHit hit;
    public GameObject shotPoint;
    public float gunDamage;
    public bool hasBought, hasEquipped;
    public ParticleSystem muzzleFlash;
    // Start is called before the first frame update
    void Start()
    {
        hasBought = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            Shoot(100f);
            muzzleFlash.Play();
            Debug.Log("shot");

        }
    }
    void Shoot(float range)
    {
        
        if(hasBought == true)
        {
            if (Physics.Raycast(shotPoint.transform.position, shotPoint.transform.forward, out hit, range))
            {

                Alien enemy = hit.rigidbody.GetComponent<Alien>();
                UFO ufo = hit.rigidbody.GetComponent<UFO>();
                
                if( enemy != null)
                {
                    enemy.ahealth -= gunDamage;
                }

                if(ufo != null)
                {
                    ufo.ufoHealth -= gunDamage;
                }




            }
            else
            {
                Debug.Log("Miss");
            }
        }
        
    }
   
}
