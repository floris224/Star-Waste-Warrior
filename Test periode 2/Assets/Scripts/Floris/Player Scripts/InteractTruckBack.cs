using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTruckBack : MonoBehaviour
{
    public RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 10))
            {
                if (hit.transform.tag == "VuilnisWagenCapaciteit")
                {
                    hit.transform.GetComponent<VuilniswagenCapaciteit>().PutTrashInTruck();
                }
            }
        }
    }
}
