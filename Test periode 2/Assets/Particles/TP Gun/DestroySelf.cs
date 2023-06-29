using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float timeStamp;
    // Start is called before the first frame update
    void Start()
    {
        timeStamp = Time.time + 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeStamp)
        {
            Destroy(gameObject);
        }
    }
}
