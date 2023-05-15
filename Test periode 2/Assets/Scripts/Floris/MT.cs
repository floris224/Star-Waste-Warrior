using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MT : MonoBehaviour
{
    public GameObject vrachtWagen;
    public Rigidbody rb;
    public float moveSpeed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
    public void movement()
    {
        float hor = -Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * hor * moveSpeed * Time.deltaTime;
        rb.AddForce(movement);

        Vector3 rotate = transform.right * vert * moveSpeed * Time.deltaTime;
        rb.AddForce(rotate);
    }
}
