using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Camera playerCam;
    public GameObject playerGrav;
    public GameObject panelShop;
    public GameObject panelShopMenu;
    private DefaultActionMap actionMap;
    private InputAction interact;
    private RaycastHit hit;
    public Camera camInGrav;
    public Button leave;
    public PickupPricker ui;
    public PaymentManager paymentManager;
    public Button payMent;
    public bool shopMenuOpen = false;



    void Awake()
    {
        actionMap = new DefaultActionMap();
        
    }

    void OnEnable()
    {
        interact = actionMap.PlayerInForcefield.Interact;
        interact.Enable();
    }

    void OnDisable()
    {
        interact.Disable();
    }

    

    void Update()
    {
        if (interact.triggered)
        {
            if (!shopMenuOpen)
            {
                if (Physics.Raycast(camInGrav.transform.position, camInGrav.transform.forward, out hit, 2f))
                {
                    if (hit.transform.tag == "ShopKeeper")
                    {
                        playerGrav.GetComponent<MovementinGrav>().enabled = false;
                        playerCam.GetComponent<Look>().enabled = false;
                        Debug.Log("ShopKeeper");

                        ShopManager();

                    }
                }
            }
           
        }
        
    }

    public void Shop()
    {
       
        panelShop.SetActive(true);
        ui.UpdateUI();

    }

    public void ShopManager()
    {
        panelShopMenu.SetActive(true);
        shopMenuOpen = true;
    }

    public void Leave()
    {
        panelShop.SetActive(false);
    }
    
    public void Exit()
    {
        panelShopMenu.SetActive(false);
        playerGrav.GetComponent<MovementinGrav>().enabled = true;
        playerCam.GetComponent<Look>().enabled = true;
        shopMenuOpen = false;
    }


    private float interactInput()
    {
        return interact.ReadValue<float>();
    }
    
    
   
    

}
