using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
using Unity.VisualScripting;
using UnityEngine.Rendering.Universal;
using UnityEditor.Rendering.Universal;

public class PlayerHealth : MonoBehaviour
{
    [Range(0,100)]
    public float health; // save
    public GameObject healthBar;
    public TMP_Text healthProcent;
    public float procent;
    public Volume blood;
    public Vignette vignette;
    public float vigFloat;
    public float timeStamp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        blood.profile.TryGet(out vignette);
        {
            vignette.intensity.value = vigFloat;
        }
        if (Time.time > timeStamp)
        {
            vigFloat -= 0.07f * Time.deltaTime;
        }
        
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
        if (vigFloat < 0.2f)
        {
            vigFloat = 0.4f;
        }
        else
        {
            vigFloat += 0.2f;
        }
        
        timeStamp = Time.time + 5;
    }
    void Death()
    {
        Debug.Log("You're Death");
        // Play UI Gameover
    }
}

