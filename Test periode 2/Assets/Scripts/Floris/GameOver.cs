using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;


    

    

    public void ShowGameOverUI()
    {
        gameOverPanel.SetActive(true);
     
    }
}