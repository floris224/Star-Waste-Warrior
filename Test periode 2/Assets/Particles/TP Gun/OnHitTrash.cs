using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitTrash : MonoBehaviour
{
    private float timeStamp, timeExplode;
    private float r;
    private bool exploded;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        r = gameObject.GetComponent<ParticleSystem>().shape.radius;
        // ps andere waarde op basis van tag small medium of groot
       
    }

    // Update is called once per frame
    void Update()
    {
        ParticleSystem.ShapeModule psShape = gameObject.GetComponent<ParticleSystem>().shape;
        ParticleSystem.EmissionModule psEmission = gameObject.GetComponent<ParticleSystem>().emission;

        
        psShape.radius = r;
        if (r > 0f && Time.time > timeStamp)
        {
            r -= 0.01f;
            timeStamp = Time.time + 0.01f;
            timeExplode = Time.time + 0.5f;
        }
        if (r <= 0.0001f)
        {
            
            psEmission.rateOverTime = 0;
            if (Time.time > timeExplode)
            {
                if (exploded == false)
                {
                    Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
                    exploded = true;
                }
            }
           
        }
    }
}
