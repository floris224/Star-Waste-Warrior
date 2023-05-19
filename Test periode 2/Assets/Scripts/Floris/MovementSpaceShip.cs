using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSpaceShip : MonoBehaviour
{
    
    public Rigidbody rb;
    public Vector3 inputKey;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void FixedUpdate()
    {
        rb.AddForce(inputKey * 50);
    }
}
