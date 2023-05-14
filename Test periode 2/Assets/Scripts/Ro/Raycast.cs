using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public RaycastHit hit;
    public VuilniswagenCapaciteit truckcap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5))
        {
            
            if (hit.transform.tag == "VuilniswagenCapaciteit")
            {
                // Show ui press e
                if (Input.GetKeyDown("e"))
                {
                    truckcap.PutTrashInTruck();
                }
                
            }
        }
    }
}
