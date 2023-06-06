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
    private float timeStamp, timeStamp2;
    public float attackCooldown, targetCooldown;
    public float distance;
    public Animator alien;
    public MusicInGame music;
    public bool isThisAlienChasing;
    public ParticleSystem particleHit;
    public GameObject gt1, gt2, gt3;
    public Vector3 target;
    public int random;
    public bool resetTarget;
    // Start is called before the first frame update
    void Start()
    {
        music = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicInGame>();
        player = GameObject.FindGameObjectWithTag("Player");
        gt1 = GameObject.Find("Target1");
        gt2 = GameObject.Find("Target2");
        gt3 = GameObject.Find("Target3");
    }

    // Update is called once per frame
    void Update()
    {
        // Als er meer dan 3 enemies achter je aan komen
        if (music.numberOfAliensChasing >= 3)
        {
            //Random kans om de targetcooldown als random onder de 50 is kies een random target rondom de player anders ga op de player af
            if (Time.time > timeStamp2)
            {
                random = Random.Range(1, 100);
                resetTarget = false;
                timeStamp2 = Time.time + targetCooldown;
            }
            if (resetTarget == false)
            {
                if (random <= 20)
                {
                    target = gt1.transform.position;
                }
                if (random > 20 && random <= 40)
                {
                    target = gt2.transform.position;
                }
                if (random > 40 && random <= 60)
                {
                    target = gt3.transform.position;
                }
                else
                {
                    target = player.transform.position;
                }
            }
            // Als de enemy niet de player target en te dichtbij die target komt target dan de player
            if (target == gt1.transform.position || target == gt2.transform.position || target == gt3.transform.position)
            {
                if (Vector3.Distance(target, transform.position) < 0.1f)
                {
                    resetTarget = true;
                }
            }
            if (resetTarget == true)
            {
                target = player.transform.position;
            }
        }
        else
        {
            target = player.transform.position;
        }
       
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
        transform.LookAt(target);
        alien.SetBool("isSwimming" , true);
        alien.SetBool("isAware", false);
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
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
        music.numberOfAliensChasing -= 1;
        // Play Alien death SFX
        particleHit.Emit(12);
        Destroy(gameObject);
        
        
       
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
