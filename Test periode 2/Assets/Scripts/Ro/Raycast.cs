using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public RaycastHit hit;
    public VuilniswagenCapaciteit truckcap;
    public Quest quest;
    public ControllerSwitch controllerSwitch;
    public PickupPricker ui;
    public string[] tags;
    public GameObject f;
    public GameObject victoryPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5))
        {
            if (hit.collider.tag == "Victory")
            {
                if (quest.questcomplete == 5)
                {
                    if (Input.GetKeyDown("f"))
                    {
                        victoryPanel.SetActive(true);
                        Time.timeScale = 0;
                    }
                }
            }
            for (int i = 0; i < tags.Length; i++)
            {
                if (hit.collider.tag == tags[i])
                {
                    f.SetActive(true);
                    
                }
                else
                {
                    f.SetActive(false);
                    
                }
                
            }
            //Spaceship movement toggle
            if (hit.collider.tag == "SpaceShip")
            
            if (Input.GetKeyDown("f"))
            {
                controllerSwitch.SwitchController();
                Debug.Log("Test");
            }
              
            
            //Quest System
            if (hit.collider.tag == "QuestItem")
            {
                if (quest.questininv == false && quest.queststarted == true)
                {
                    // Show ui press e
                    if (Input.GetKeyDown("f"))
                    {
                        quest.PickupQuestItem();
                        quest.ininv = hit.transform.name;
                        hit.transform.gameObject.SetActive(false);
                        
                    }
                }
               
            }
            if (hit.collider.tag == "QuestNPC")
            {
                // Show ui press e
                if (Input.GetKeyDown("f"))
                {
                    if (quest.questininv == true)
                    {
                        quest.questcomplete += 1;
                        quest.EndQuest();
                        quest.questininv = false;
                        ui.UpdateUI();
                        
                    }
                    else
                    {
                        if (quest.queststarted == false)
                        {
                            quest.StartQuest();
                        }
                        else
                        {
                            quest.Reminder();
                        }
                    }
                }
            }
            //Vuilniswagen cap system
            if (hit.collider.tag == "VuilniswagenCapaciteit")
            {
                // Show ui press e
                if (Input.GetKeyDown("f"))
                {
                    truckcap.PutTrashInTruck();
                    ui.UpdateUI();
                }
                
            }
        }
    }
}
