using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPricker : MonoBehaviour
{
    public Animator pricker;
    public Collider grabpoint;
    public GameObject end;
    public GameObject trash;
    public Collider trashcollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pricker.SetBool("leftclick", true);
            
        }
        else
        {
            pricker.SetBool("leftclick", false);
        }
    }
    public void OnTriggerEnter(Collider grabpoint)
    {
        if (grabpoint.CompareTag("TrashSmall"))
        {
            Debug.Log("Werkt");
            trash = grabpoint.gameObject;
            trashcollider = trash.GetComponent<Collider>();
            trashcollider.enabled = false;
            trash.transform.position = end.transform.position;
            trash.transform.SetParent(end.transform, true);
        }
    }
}
