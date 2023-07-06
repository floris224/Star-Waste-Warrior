using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
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
            if(Physics.Raycast(camInGrav.transform.position, camInGrav.transform.forward, out hit, 2f))
            {
                if(hit.transform.tag == "ShopKeeper")
                {
                    gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    Debug.Log("ShopKeeper");
                    
                    ShopManager();

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
    }

    public void Leave()
    {
        panelShop.SetActive(false);
    }
    
    public void Exit()
    {
        panelShopMenu.SetActive(false);
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }


    private float interactInput()
    {
        return interact.ReadValue<float>();
    }
    
    
   
    

}
