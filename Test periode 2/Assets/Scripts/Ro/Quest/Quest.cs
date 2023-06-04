using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public int questcomplete;
    public bool questininv, queststarted;
    public string ininv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartQuest()
    {
        Debug.Log("Zoek deze items voor mij. Een Nokia, Item2, Item3, Item4, Item5");
        queststarted = true;
    }
    public void EndQuest()
    {
        
        Debug.Log("Bedankt voor de " + ininv);
        if (questcomplete == 5)
        {
            Debug.Log("Nu kan je het ruimteschip gebruiken om terug te gaan naar de aarde");
        }
    }
    public void PickupQuestItem()
    {
        questininv = true;
    }
}
