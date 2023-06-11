using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienDeath : MonoBehaviour
{
    public float timestamp;
    // Start is called before the first frame update
    void Start()
    {
        timestamp = Time.time + 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timestamp)
        {
            Destroy(gameObject);
        }
    }
}
