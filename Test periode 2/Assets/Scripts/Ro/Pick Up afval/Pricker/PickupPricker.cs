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
    public bool inprikker;
    public int capaciteit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (inprikker == false)
            {
                pricker.SetTrigger("click");
            }
            else
            {
                if (capaciteit < 5)
                {
                    trash.SetActive(false);
                    inprikker = false;
                    capaciteit += 1;
                    Debug.Log("je hebt "+capaciteit+" afval");
                }
                else
                {
                    Debug.Log("Je vuilniszak zit vol");
                }
                
            }
            
        }
    }
    public void OnTriggerStay(Collider grabpoint)
    {
        if (this.pricker.GetCurrentAnimatorStateInfo(0).IsName("Prikker"))
        {
            if (inprikker == false)
            {
                if (grabpoint.CompareTag("TrashSmall"))
                {
                    Debug.Log("Werkt");
                    inprikker = true;
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
}
