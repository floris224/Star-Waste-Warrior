using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Burst;
using UnityEngine;
using UnityEngine.InputSystem;
public class Look : MonoBehaviour
{
    public float mousSens, mouseY, mouseX;
    public Vector3 dir;
    public GameObject playerBody;
    float rotY;
    public RaycastHit hit;
    public TeleportGun teleportGun;
    public PickupPricker pickupPricker;


    void Start()
    {
        

    }


    void Update()
    {

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        dir = new Vector3(0, mouseX, 0);
        playerBody.transform.Rotate(dir * mousSens * Time.deltaTime);

      
        rotY += mouseY * mousSens * Time.deltaTime;
        rotY = Mathf.Clamp(rotY, -90, 90);
        Vector3 e = transform.eulerAngles;
        e.x = -rotY;
        transform.eulerAngles = e;
        interactSell();
    }
   
    public void interactSell()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, 10f))
            {
                
                if (hit.transform.tag == "Grinder")
                {
                    pickupPricker.SellInv();
                    teleportGun.Sell();
                }
            }
        }

    }
}
