using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quest : MonoBehaviour
{
    public int questcomplete; // save
    public bool questininv, queststarted;
    public string ininv;
    public GameObject quest, okay, bye;
    public TMP_Text npcSays, questCount, inventoryCoutn, galaxyTokens, shopMoney;
    public string[] items; // save
    public GameObject player, cam;
    public Money money;
    public PickupPricker pickuppricker;
    // Start is called before the first frame update
    void Start()
    {
        items[0] = "Nokia";
        items[1] = "Chips";
        items[2] = "Red core";
        items[3] = "Blue core";
        items[4] = "Yellow core";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartQuest()
    {
        player.GetComponent<MovementinGrav>().enabled = false;
        cam.GetComponent<Look>().enabled = false;
        quest.SetActive(true);
        npcSays.text = ("Search for items that have yellow sparks");
        queststarted = true;
    }
    public void EndQuest()
    {
        player.GetComponent<MovementinGrav>().enabled = false;
        cam.GetComponent<Look>().enabled = false;
        quest.SetActive(true);   
        npcSays.text = ("Thank you for giving me " + ininv);
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == ininv)
            {
                items[i] = "";
            }
        }
        if (questcomplete == 5)
        {
            npcSays.text = ("You brought me all the items");
            okay.SetActive(true);
            bye.SetActive(false);
        }
    }
    public void PickupQuestItem()
    {
        questininv = true;
    }

    public void Okay()
    {
        npcSays.text = "When you find one bring it back to me";
        if (questcomplete == 5)
        {
            npcSays.text = ("Now you can return to Earth with your space ship");
        }
    }

    public void Reminder()
    {
        player.GetComponent<MovementinGrav>().enabled = false;
        cam.GetComponent<Look>().enabled = false;
        quest.SetActive(true);
        if (questcomplete == 5)
        {
            npcSays.text = ("You can return to Earth with your space ship");
        }
        else
        {
            npcSays.text = ("I still need: " + items[0] + " " + items[1] + " " + items[2] + " " + items[3] + " " + items[4]);
        }
        
    }

    public void Bye()
    {
        player.GetComponent<MovementinGrav>().enabled = true;
        cam.GetComponent<Look>().enabled = true;
    }

    public void UpdateUI()
    {
        questCount.text = "Quest: " + questcomplete + "/ 5";
        inventoryCoutn.text = "Inventory: " + pickuppricker.capaciteit + "/5";
        galaxyTokens.text = "Money: " + money.geld;
        
    }
}
