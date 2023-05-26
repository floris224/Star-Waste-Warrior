using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pay : MonoBehaviour
{

    public GameObject rItem;
    public GameObject bItem;
    public float totalPrice = 0f;
    public ItemPrice ropePrice;
    public ItemPrice boosterPrice;
    public Money pMoney;
    public RaycastHit hit;
   // public MT mt;
   // public Movement movement;
    // Start is called before the first frame update
    public void Start()
    {
        
    }
    public void Update()
    {
       
       
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 3f))
            {
                if (hit.rigidbody.CompareTag("UpgradeBooster"))
                {
                    UpgradeBooster();
                }
                else if ( hit.rigidbody.CompareTag("UpgradeRope"))
                {
                    RopeUpgrade();

                }
            }

        }

    }

    public void UpgradeBooster()
    {
         if (pMoney.geld < boosterPrice.price)
         {
                Debug.Log("niet genoeg");
         }
         else
         {
                pMoney.geld -= boosterPrice.price;

                bItem.SetActive(false);
                Debug.Log("totaal kost = " + boosterPrice.price);
               // mt.moveSpeed = 20f;
                
                

         }
            
        
    }
    public void RopeUpgrade()
    {
       
      
         if (pMoney.geld < ropePrice.price)
         {
          Debug.Log("niet genoeg");
         }
         else
         {
           pMoney.geld -= ropePrice.price;
           rItem.SetActive(false);
           Debug.Log("totaal kost = " + ropePrice.price);
            //movement.maxDís = 10f;

         }

                

            
    }
}

    

   

    



  



