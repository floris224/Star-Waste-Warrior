using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaymentManager : MonoBehaviour
{
    public GameObject panelGameOverNoMoney;
    public GameObject gameOverPanel, ticketPanel;
    public GameOver gameOver;
    public PlayerHealth playerHealth;
    public SpaceShipMovement spaceShipMovement;
    public MovementinGrav movementInGrav;
    public SpaceMovement spaceMovement;
    public Money money;
    public MenuManager menuManager;

    public void Update()
    {
        if (playerHealth.health == 0 || spaceShipMovement.currentEngineFuel == 0)
        {
            HandlePayment();
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
            movementInGrav.ResetPosition();
        }
        else if (spaceShipMovement.currentEngineFuel == 0)
        {
            gameOverPanel.SetActive(true);
            ticketPanel.SetActive(true);
            paymentAmount = 150;
            if (money.geld >= minimumMoney)
            {
                spaceShipMovement.currentEngineFuel += paymentAmount;
                money.geld -= paymentAmount;
            }
            else if (money.geld <= minimumMoney)
            {
                GameOver();
                Time.timeScale = 0f;
                return;
            }
        }

        if (money.geld >= paymentAmount)
        {
            gameOverPanel.SetActive(false);
            Time.timeScale = 1f;
        }
        else if (money.geld <= minimumMoney)
        {
            GameOver();
            Time.timeScale = 0f;
        }
    }
}


