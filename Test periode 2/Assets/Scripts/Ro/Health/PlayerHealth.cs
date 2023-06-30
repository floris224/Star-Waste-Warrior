using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [Range(0,100)]
    public float health;
    public GameObject healthBar;
    public TMP_Text healthProcent;
    public float procent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        procent = health / 100;
        healthProcent.text = health.ToString();
        healthBar.GetComponent<Slider>().value = procent;
        if (health <= 0)
        {
            health = 0;
            Death();
        }
    }
    public void Getdamage()
    {
        health -= 5;
    }
    void Death()
    {
        Debug.Log("You're Death");
        // Play UI Gameover
    }
}

