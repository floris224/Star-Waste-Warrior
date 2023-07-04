using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VuilniswagenCapaciteit : MonoBehaviour
{
    public PickupPricker prickercap;
    public int[] capaciteitLimiet;
    public GameObject[] trash;
    public List<int> capaciteitList;
    public int capaciteit, activeLimit;
    public bool upgraded;
    // Start is called before the first frame update
    void Start()
    {
        if (upgraded == true)
        {
            activeLimit = capaciteitLimiet[1];
        }
        else
        {
            activeLimit= capaciteitLimiet[0];
        }
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
        if (prickercap.capaciteit + capaciteit < activeLimit)
        {
            capaciteitList = prickercap.capaciteitList;
            prickercap.capaciteitList.Clear();
        } 
    }

    public void Upgrade()
    {
        activeLimit = capaciteitLimiet[1];
        upgraded = true;
    }
}
