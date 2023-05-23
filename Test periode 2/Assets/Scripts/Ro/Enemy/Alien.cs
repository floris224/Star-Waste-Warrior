using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Alien : MonoBehaviour
{
    public GameObject player;
    public int ahealth;
    public int damage;
    public float maxFollowRange, minFollowRange;
    public float attackRange;
    public float speed;
    private float timeStamp;
    public float attackCooldown;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        speed *= 0.001f;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (ahealth <= 0)
        {
            ahealth = 0;
            Die();
        }

        
        if (distance  <= maxFollowRange && distance > minFollowRange)
        {
            print("I see you");
            Chase();
        }
        else
        {
            // walk around idle
        }

    }

    void Chase()
    {

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
        if (distance <= attackRange)
        { 
            Attack();
        }
    }
    void Attack()
    {
        if (Time.time > timeStamp)
        {
            player.GetComponent<PlayerHealth>().Getdamage();
            timeStamp = Time.time + attackCooldown;
        }
            
    }
    void Die()
    {
        Debug.Log("Alien Defeated");
        transform.gameObject.SetActive(false);
        // Play Alien death SFX
        // Play Alien death particle
    }
}
