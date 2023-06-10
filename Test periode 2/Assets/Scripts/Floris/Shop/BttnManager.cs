using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BttnManager : MonoBehaviour
{
    public GameObject optionMenu;
    public GameObject panelShop;
    public Button leave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Leave()
    {
        panelShop.SetActive(false);
    }
    public void OpenShop()
    {
        panelShop.SetActive(true);
    }
    public void Exit()
    {
        optionMenu.SetActive(false);
    }
}
