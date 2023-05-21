using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public PlayerHealth playerhp;
    public int health;
    public int damage;
    public Transform player;
    public float followRange;
    public float attackRange;
    public float speed;
    private float timeStamp;
    public float attackCooldown;
    // Start is called before the first frame update
    void Start()
    {
        speed *= 0.001f;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            health = 0;
            Die();
        }

        if (Vector3.Distance(player.position, transform.position) <= followRange)
        {
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
        if (Vector3.Distance(player.position, transform.position) <= attackRange)
        {
            Attack();
        }
    }
    void Attack()
    {
        if (Time.time > timeStamp)
        {
            playerhp.health -= 20;
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
