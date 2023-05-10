using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pay : MonoBehaviour
{

    public GameObject bItem;
    public float totalPrice = 0f;
    public Booster item;
    public Money pMoney;
    public RaycastHit hit;
    public MT mt;
    // Start is called before the first frame update
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(Physics.Raycast(transform.position,transform.forward, out hit, 3f))
            {
                if(hit.rigidbody.tag == "Upgrade")
                {
                    if (pMoney.geld < item.price)
                    {
                        Debug.Log("niet genoeg");
                    }
                    else
                    {
                        pMoney.geld -= item.price;
                        bItem.SetActive(false);
                        Debug.Log("totaal kost = " + totalPrice);
                        mt.moveSpeed = 20f;

                    }

                }
                
            }
        }
            
    }
        
}

    

   

    



  



