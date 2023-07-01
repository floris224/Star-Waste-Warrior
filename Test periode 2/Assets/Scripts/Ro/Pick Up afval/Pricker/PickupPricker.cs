using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickupPricker : MonoBehaviour
{

    public Animator pricker;
    public Collider grabpoint;
    public GameObject end;
    public GameObject trash;
    public Collider trashcollider;
    public bool inprikker;
    public int capaciteit;
    public int damage;
    private float timeStampAttack, timeStampHit;
    public float attackCooldown, hitcooldown;
    public int maxCapacity;
   
    public TextMeshProUGUI questCount, inventoryCoutn, galaxyTokens, shopMoney;
    public Quest quest;
    public Money money;
    private int currentMoney;
    private RaycastHit hit;
    public AudioSource alienHit;

    private void Start()
    {
        //int CurrentMoney = money.geld;
        UpdateUI();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (inprikker == true)
        {
            trash.transform.position = end.transform.position;
            trash.transform.rotation = end.transform.rotation;
            pricker.SetBool("inGrapper", true);
        }
        if (Input.GetMouseButtonDown(0) && (Time.time > timeStampAttack))
        {
            pricker.SetTrigger("leftclick");
            timeStampAttack = Time.time + attackCooldown;
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (inprikker == false)
            {
                pricker.SetTrigger("click");
            }
            else
            {
                
                if (capaciteit < 5)
                {
                    pricker.SetBool("inGrapper", false);
                    trash.SetActive(false);
                    inprikker = false;
                    capaciteit += 1;
                    


                    Debug.Log("je hebt " + capaciteit + " afval");
                }
                else
                {
                    Debug.Log("Je vuilniszak zit vol");
                }

            }

        }
    }
    public void OnTriggerStay(Collider grabpoint)
    {
        if (this.pricker.GetCurrentAnimatorStateInfo(0).IsName("Armature|Slam"))
        {
            if (grabpoint.CompareTag("Enemy") && (Time.time > timeStampHit))
            {
                grabpoint.gameObject.GetComponent<Alien>().ahealth -= damage;
                grabpoint.gameObject.GetComponent<Alien>().particleHit.Emit(6);
                alienHit.Play();
                timeStampHit = Time.time + hitcooldown;

            }
        }
        if (this.pricker.GetCurrentAnimatorStateInfo(0).IsName("Armature|Pick up "))
        {
            if (inprikker == false)
            {
                if (grabpoint.CompareTag("TrashSmall"))
                {

                    inprikker = true;
                    trash = grabpoint.gameObject;
                    trashcollider = trash.GetComponent<Collider>();
                    trashcollider.enabled = false;
                    trash.GetComponent<Rigidbody>().freezeRotation = true;
                    trash.transform.SetParent(end.transform, true);
                }
            }
           
            

        }

    }
   
    
    
    
    public void UpdateUI()
    {
        questCount.text = "Quest: " + quest.questcomplete + "/ 5"; 
        
        galaxyTokens.text = "Money: " + money.geld;
        shopMoney.text = "Money: " + money.geld;
}   }
