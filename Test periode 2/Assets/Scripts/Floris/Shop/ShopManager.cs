using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject spaceshipMark1, spaceshipMark2;
    public TeleportGun teleportGun;
    public GameObject gun, lasergun, truckBackm2, truckBackm1, spaceShip;
    public Money cash;
    public TMP_Text coinUI;
    public Shopitem[] shopItemSO;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseBtns;
    public SpaceMovement boost, ropeDistance;
    public float speed;
    public SpaceMovement player;
    public GameObject playerInSpace;
    public PickupPricker ui;
    public VuilniswagenCapaciteit vuilniswagenCapaciteit;
    public Button refuelButton;
    public WeaponSwitch weaponSwitch;
    private bool[] weaponPurchased;
    public bool gunGot;

    // Start is called before the first frame update
    void Start()
    {
        weaponPurchased = new bool[shopItemSO.Length];
        speed = boost.thrust;
        refuelButton.onClick.AddListener(Refuel);
    }

    // Update is called once per frame
    void Update()
    {
        CheckCanBuy();
        CoinsUI();
        LoadPanel();
    }

    public void CoinsUI()
    {
        coinUI.text = "Galaxy Tokens: " + cash.geld.ToString();
    }

    public void LoadPanel()
    {
        for (int i = 0; i < shopItemSO.Length; i++)
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
        if (btnNo >= 0 && btnNo < shopItemSO.Length)
        {
            if (cash.geld >= shopItemSO[btnNo].cost)
            {
                cash.geld -= shopItemSO[btnNo].cost;
                coinUI.text = "Galaxy Tokens: " + cash.geld.ToString();
                CheckCanBuy();
                ui.UpdateUI();
                myPurchaseBtns[btnNo].interactable = false;
                ActivateItem(btnNo);
               
            }
        }
    }

    private void MarkWeaponPurchased(int weaponIndex)
    {
        weaponPurchased[weaponIndex] = true;
    }

    private void ActivateItem(int btnNo)
    {
        switch (btnNo)
        {
            case 0: // Boosters
                speed = 600f;
                break;
            case 1: // Rope
                ropeDistance.maxDis = 30;
                break;
            case 2: // gun
                gunGot = true;
                weaponSwitch.weapons.Add(gun);
                
                break;
            case 3: // Lasergun
                teleportGun.bought = true;
                weaponSwitch.weapons.Add(lasergun);
                Debug.Log("Bought");
               
                break;

            case 4: // TruckFront
                spaceshipMark1.SetActive(false);
                spaceshipMark2.SetActive(true);
                break;
            case 5:// TruckBack
                truckBackm1.SetActive(false);
                truckBackm2.SetActive(true);
                vuilniswagenCapaciteit.maxCapacitySpaceShip = 10;
                break;
            case 6: //FuelUpgrade
                spaceShip.GetComponent<SpaceShipMovement>().maxEngineFuel = 400;

                break;
            case 7: // medkit
                int medKidCost = 50;
                if (cash.geld >= medKidCost)
                {
                    cash.geld -= medKidCost;
                    coinUI.text = "Galaxy Tokens: " + cash.geld.ToString();
                    playerInSpace.GetComponent<PlayerHealth>().health += 50;
                }
                break;

        }
    }
    public void Refuel()
    {
        int refuelCost = 200;
        if (cash.geld >= refuelCost)
        {
            cash.geld -= refuelCost;
            coinUI.text = "Galaxy Tokens: " + cash.geld.ToString();
            spaceShip.GetComponent<SpaceShipMovement>().currentEngineFuel = spaceShip.GetComponent<SpaceShipMovement>().maxEngineFuel;
        }
        else
        {
            
            Debug.Log("No Money");
        }
    }
}    