using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Conversation : MonoBehaviour
{
    public TMP_Text npc, response1, response2;
    public GameObject button1, button2, byeButton, player, cam;
    public SoConvo conversation;
    public int npcIndex, resp1Index, resp2Index, stage;
    // Start is called before the first frame update
    void Start()
    {
        npcIndex = 0;
        resp1Index = 1;
        resp2Index = 2;
        byeButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        npc.text = conversation.npcSays[npcIndex];
        response1.text = conversation.youSay[resp1Index];
        response2.text = conversation.youSay[resp2Index];
        print(conversation.youSay.Length - 1);

        if (stage > 1)
        {
            print("jaaaaaa");
            
            button1.SetActive(false);
            button2.SetActive(false);
            byeButton.SetActive(true);
            resp1Index = 0;
            resp2Index = 0;
        }
    }

    public void Response1()
    {
        stage += 1;
        if (stage <= 1)
        {
            resp1Index *= 2;
            resp1Index += 1;
            resp2Index = resp1Index + 1;
        }
        npcIndex *= 2;
        npcIndex += 1;
    }

    public void Response2()
    {
        stage += 1;
        if (stage <= 1)
        {
            resp2Index *= 2;
            resp2Index += 2;
            resp1Index = resp2Index - 1;
        }
        npcIndex *= 2;
        npcIndex += 2;
    }

    public void EndConvo()
    {
        button1.SetActive(true);
        button2.SetActive(true);
        byeButton.SetActive(false);
        npcIndex = 0;
        resp1Index = 1;
        resp2Index = 2;
        stage = 0;
        player.GetComponent<MovementinGrav>().enabled = true;
        cam.GetComponent<Look>().enabled = true;
    }

}
