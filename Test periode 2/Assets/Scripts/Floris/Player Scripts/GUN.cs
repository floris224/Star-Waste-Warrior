using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;


public class GUN : MonoBehaviour
{
    public  RaycastHit hit;
    public GameObject shotPoint, gunSound;
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
            gunSound.GetComponent<AudioSource>().Play();

        }
    }
    void Shoot(float range)
    {

        if (Physics.Raycast(shotPoint.transform.position, shotPoint.transform.forward, out hit, range))
        {

           

            if (hit.transform.CompareTag("UFO"))
            {
                UFO ufo = hit.rigidbody.GetComponent<UFO>();
                ufo.ufoHealth -= gunDamage;
            }
            else if (hit.transform.CompareTag("Enemy"))
            {
                Alien enemy = hit.rigidbody.GetComponent<Alien>();
                enemy.ahealth -= gunDamage;
            }
           




        }
        else
        {
            Debug.Log("Miss");
        }



    }
   
}
