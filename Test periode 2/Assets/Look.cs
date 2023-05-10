using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Look : MonoBehaviour
{
    public float mousSens, mouseY, mouseX;
    public Vector3 dir;
    public GameObject playerBody;
    float rotY;

    void Update()
    {
        //defineren welke as wat doet
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        // defineren van de vector3 over welke as hij zal moeten draaien
        dir = new Vector3(0, mouseX, 0);
        playerBody.transform.Rotate(dir * mousSens * Time.deltaTime);

        // defineren over welke as de camera moet draaien & het clampen van de rotatie.
        rotY += mouseY * mousSens * Time.deltaTime;
        rotY = Mathf.Clamp(rotY, -90, 90);
        Vector3 e = transform.eulerAngles;
        e.x = -rotY;
        transform.eulerAngles = e;
    }
}
