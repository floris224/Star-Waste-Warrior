using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

public class ShopManager : MonoBehaviour
{
    public GameObject gun;
    public Money cash;
    public TMP_Text coinUI;
    public Shopitem[] shopItemSO;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseBtns;
    public SpaceMovement boost;
    public float speed;
    public float distance;
    public SpaceMovement player;
    public PickupPricker ui;
    // Start is called before the first frame update
    void Start()
    {
        distance = player.maxDis;
        speed = boost.thrust;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        CheckCanBuy();
        CoinsUI();
        loadPanel();
    }
    public void CoinsUI()
    {
        coinUI.text = "Galaxy Tokens::" + cash.geld.ToString();
    }
    public void loadPanel()
    {
        for(int i = 0; i < shopItemSO.Length; i++)
        {
            shopPanels[i].titleText.text = shopItemSO[i].title;
            shopPanels[i].priceText.text = "Price: " + shopItemSO[i].cost.ToString();
        }
    }
    public void CheckCanBuy()
    {
        for (int i = 0; i < shopItemSO.Length; i++)
        {
            if (cash.geld >= shopItemSO[i].cost)
            {
                myPurchaseBtns[i].interactable = true; 
            }
            else
            {
                myPurchaseBtns[i].interactable = false;
            }

        }
    }
    public void PurchaseItem(int btnNo)
    {
        if(cash.geld >= shopItemSO[btnNo].cost)
        {
            cash.geld = cash.geld - shopItemSO[btnNo].cost;
            coinUI.text = "Money: " + cash.geld.ToString();
            CheckCanBuy();
            ui.UpdateUI();
        }
        if (myPurchaseBtns[0])
        {
            speed = 300f;
        }
        if (myPurchaseBtns[1])
        {
            Debug.Log("GotGun");
        }
        if (myPurchaseBtns[2])
        {
            distance = 30f;
        }
    }

}
