using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Button paymentButton;

    private MenuManager menuManager;

    public void Initialize(MenuManager menuManager)
    {
        this.menuManager = menuManager;

        //paymentButton.onClick.AddListener(menuManager.HandlePayment);
    }

    public void ShowGameOverUI()
    {
        gameOverPanel.SetActive(true);
     
    }
}