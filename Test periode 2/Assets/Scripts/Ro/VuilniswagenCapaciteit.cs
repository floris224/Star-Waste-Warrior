using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VuilniswagenCapaciteit : MonoBehaviour
{
    public PickupPricker prickercap;
    public int capaciteit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
