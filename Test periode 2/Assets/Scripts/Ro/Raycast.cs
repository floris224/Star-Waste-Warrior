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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5))
        {
            //Spaceship movement toggle
            if (hit.collider.tag == "SpaceShip")
            {
                if (Input.GetKeyDown("f"))
                {
                    controllerSwitch.SwitchController();
                    Debug.Log("Test");
                }
              
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
                }
                
            }
        }
    }
}
