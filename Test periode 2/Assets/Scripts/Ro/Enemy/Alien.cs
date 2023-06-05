using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public Animator alien;
    public MusicInGame music;
    public bool isThisAlienChasing;
    // Start is called before the first frame update
    void Start()
    {
        music = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicInGame>();
        speed *= 0.001f;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (ahealth <= 0)
        {
            //play death particles
            ahealth = 0;
            Die();
        }

        
        if (distance  <= maxFollowRange && distance > minFollowRange)
        {
            Debug.Log("I see you");
            Chase();
        }
        if (distance > maxFollowRange)
        {
            alien.SetBool("isAware", true);
            alien.SetBool("isSwimming", false);
            SetAlienChaseFalse();
            
        }
        if (distance <= attackRange)
        {
            Attack();
        }
       

    }

    void Chase()
    {
        transform.LookAt(player.transform.position);
        alien.SetBool("isSwimming" , true);
        alien.SetBool("isAware", false);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
        if (isThisAlienChasing == false)
        {
            music.numberOfAliensChasing += 1;
            isThisAlienChasing = true;
        }
        
    }
    void Attack()
    {
        if (Time.time > timeStamp)
        {
            alien.SetTrigger("isAttacking");
            player.GetComponent<PlayerHealth>().Getdamage();
            timeStamp = Time.time + attackCooldown;
        }
            
    }
    void Die()
    {
        Debug.Log("Alien Defeated");
        transform.gameObject.SetActive(false);
        SetAlienChaseFalse();
        // Play Alien death SFX
        // Play Alien death particle
    }
    public void SetAlienChaseFalse()
    {
        if (isThisAlienChasing == true)
        {
            music.numberOfAliensChasing -= 1;
            isThisAlienChasing = false;
        }
    }
}
