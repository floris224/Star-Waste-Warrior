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
        if (Input.GetMouseButtonDown(1))
        {
            pricker.SetTrigger("click");
        }
    }
    public void OnTriggerStay(Collider grabpoint)
    {
        if (grabpoint.CompareTag("TrashSmall"))
        {
            Debug.Log("Werkt");
            if (this.pricker.GetCurrentAnimatorStateInfo(0).IsName("Prikker"))
            {
                
                trash = grabpoint.gameObject;
                trashcollider = trash.GetComponent<Collider>();
                trashcollider.enabled = false;
                trash.transform.position = end.transform.position;
                trash.GetComponent<Rigidbody>().freezeRotation = true;
                trash.transform.rotation = end.transform.rotation;
                trash.transform.SetParent(end.transform, true);
            }
        }
    }
}
