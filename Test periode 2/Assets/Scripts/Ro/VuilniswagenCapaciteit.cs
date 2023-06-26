using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VuilniswagenCapaciteit : MonoBehaviour
{
    public PickupPricker prickercap;
    public int capaciteit;
    public GameObject[] trash; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (capaciteit < 1)
        {
            for (int i = 0; i < trash.Length; i++)
            {
                trash[i].SetActive(false);
            }
        }
        if (capaciteit >= 1 && capaciteit < 5)
        {
            trash[0].SetActive(true);
            for (int i = 1; i < trash.Length; i++)
            {
                trash[i].SetActive(false);
            }
        }
        if (capaciteit >= 5 && capaciteit < 10)
        {
            trash[0].SetActive(true);
            trash[1].SetActive(true);
            for (int i = 2; i < trash.Length; i++)
            {
                trash[i].SetActive(false);
            }
        }
        if (capaciteit >= 10 && capaciteit < 15)
        {
            trash[0].SetActive(true);
            trash[1].SetActive(true);
            trash[2].SetActive(true);
            for (int i = 3; i < trash.Length; i++)
            {
                trash[i].SetActive(false);
            }
        }
    }

    public void PutTrashInTruck()
    {
        capaciteit += prickercap.capaciteit;
        prickercap.capaciteit = 0;
        Debug.Log("Je hebt " + capaciteit + " vuilnis in je vuilniswagen en je vuilniszak is leeg " + prickercap.capaciteit);
        if (capaciteit >= 10)
        {
            capaciteit = 10;
            Debug.Log("Je vuilniswagen zit vol");
        }
    }
}
