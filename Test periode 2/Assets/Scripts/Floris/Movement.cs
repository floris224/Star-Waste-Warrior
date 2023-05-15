using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject player;
    public Transform vrachtwagen;
    public Rigidbody rb;
    public float speed = 10;
    public float turnSpeed = 10;
    public float maxDís = 10f;

    public float strenght = 10f;
    public float impuls;
    public float fallBack = 0f;
    public float maxC;
    public float minC; 

    // Start is called before the first frame update
    void Start()
    {
      
       rb = GetComponent<Rigidbody>();
    }
   
    // Update is called once per frame
    void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
      
        float disV = Vector3.Distance(transform.position, vrachtwagen.position);
        if (disV > maxDís)
        {
            Vector3 direction = (transform.position - vrachtwagen.position).normalized;
            rb.AddForce(direction * strenght);
            

               
        }
        else if (disV < maxDís)
        {
            
            Vector3 rotation = new Vector3(0f, hor * turnSpeed, 0f * Time.deltaTime);
            rb.AddTorque(rotation);

            float angle = vert * turnSpeed;
            Quaternion rotationUpDown = Quaternion.Euler(-angle, 0, 0);
            player.transform.localRotation *= rotationUpDown;

           /* float clampedAngle = Mathf.Clamp(player.transform.localRotation.eulerAngles.x, minC, maxC);
            player.transform.localRotation = Quaternion.Euler(clampedAngle, player.transform.localRotation.eulerAngles.y, player.transform.localRotation.eulerAngles.z);*/

            // frans idee rotation naar 0 dan movement 


            if (Input.GetKeyDown(KeyCode.Q))
            {
                Vector3 movement = transform.forward * impuls * Time.deltaTime;
                rb.AddForce(movement, ForceMode.Impulse);
                Debug.Log("test");
            }
        }
        
    }   
}
