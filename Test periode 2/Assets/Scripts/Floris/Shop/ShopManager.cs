using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

public class ShopManager : MonoBehaviour
{
    public Money cash;
    public TMP_Text coinUI;
    public Shopitem[] shopItemSO;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseBtns;

    // Start is called before the first frame update
    void Start()
    {
        loadPanel();
        CheckCanBuy();
        CoinsUI();
    }

    // Update is called once per frame
    void Update()
    {
        
        
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
            shopPanels[i].descriptionText.text = shopItemSO[i].description;
            shopPanels[i].priceText.text = "Galaxy Tokens" + shopItemSO[i].cost.ToString();
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
            coinUI.text = "Galaxy Tokens: " + cash.geld.ToString();
            CheckCanBuy();
        }
    }
}
