using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M2 : MonoBehaviour
{
    public float hor, vert;
    public Vector3 dir;
    public float walkSpeed;

    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        dir.x = hor;
        dir.z = vert;
        Walk();
    }
    
    public void Walk()
    {
        transform.Translate(dir * walkSpeed * Time.deltaTime);

    }



}

