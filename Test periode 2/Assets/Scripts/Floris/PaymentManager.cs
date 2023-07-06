using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PaymentManager : MonoBehaviour
{
    public GameObject playerInSpace, playerInGrav;
    public GameObject panelGameOverNoMoney;
    public GameObject gameOverPanel, ticketPanel;
    public Camera spaceCamera, gravCamera;

    public PlayerHealth playerHealth;
    public SpaceShipMovement spaceShipMovement;
    public MovementinGrav movementInGrav;
    public SpaceMovement spaceMovement;
    public Money money;
    public MenuManager menuManager;
    public ControllerSwitch locationSwitch;
   
    public Button paymentButton;
   
    

    public void Start()
    {
       paymentButton.onClick.AddListener(HandlePayment);
    }
    public void Update()
    {
        if (playerHealth.health == 0 || spaceShipMovement.currentEngineFuel == 0)
        {
            ticketPanel.SetActive(true);
            gameOverPanel.SetActive(true);
        }
    }

    public void GameOver()
    {

        panelGameOverNoMoney.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HandlePayment()
    {
        int paymentAmount = 0;
        int minimumMoney = -1000;

        if (playerHealth.health == 0)
        {
            paymentAmount = 250;
            playerHealth.health = 100;
            Time.timeScale = 0;
            locationSwitch.SwitchController();
            spaceShipMovement.ResetPosition();



        }
        else if (spaceShipMovement.currentEngineFuel == 0)
        {
            if(money.geld >= minimumMoney)
            {
                gameOverPanel.SetActive(true);
                ticketPanel.SetActive(true);
                paymentAmount = 150;
                spaceShipMovement.canMove = false;
                
            }
            else
            {
                GameOver();
                Time.timeScale = 0f;
                return;
            }
           
           
        }

        if (money.geld >= minimumMoney && spaceShipMovement.currentEngineFuel == 0)
        {
            spaceShipMovement.currentEngineFuel += paymentAmount;
            money.geld -= paymentAmount;
            spaceShipMovement.canMove = true;
            spaceShipMovement.ResetPosition();
        }
        else if (money.geld <= minimumMoney)
        {
            GameOver();
            Time.timeScale = 0f;
            return;
        }
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }
}


