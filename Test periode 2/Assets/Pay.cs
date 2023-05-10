using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pay : MonoBehaviour
{

    public List<Booster> cart = new List<Booster>();
    public float totalPrice = 0f;
    public Booster item;
    public Money pMoney;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void inBasket()
    {
        if(pMoney.money >= item.price)
        {
            cart.Add(item);
            totalPrice += item.price;
            pMoney.money -= item.price;
            Debug.Log("totaal kost = " + totalPrice);
        }
        else
        {
            Debug.Log("nee");
        }
        

    }

    public void betalen()
    {
        cart.Clear();
        totalPrice = 0f;

    }

    



   
}


