using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Range(0,100)]
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            health = 0;
            Death();
        }
    }
    public void Getdamage()
    {
        health -= 20;
    }
    void Death()
    {
        Debug.Log("You're Death");
        // Play UI Gameover
    }
}

