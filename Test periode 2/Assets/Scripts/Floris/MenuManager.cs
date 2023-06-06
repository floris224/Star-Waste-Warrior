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
                    
                    panelShopMenu.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    interactInput();

                }
            }
        }
    }

    public void Shop()
    {
        panelShopMenu.SetActive(false);
        panelShop.SetActive(true);
    }




    private float interactInput()
    {
        return interact.ReadValue<float>();
    }
    
   
    

}
