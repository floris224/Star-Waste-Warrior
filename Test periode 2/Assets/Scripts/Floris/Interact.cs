using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    private DefaultActionMap actionMap;
    private InputAction enter;
    public RaycastHit hit;
    public GameObject playerInSpace;
    public Camera spaceShipCam;
    public GameObject spaceShip;
    
    // Start is called before the first frame update
    private void Awake()
    {
        actionMap = new DefaultActionMap();
        
    }
    private void OnEnable()
    {
        enter = actionMap.PlayerSpace.Interact;
        enter.Enable();

    }
    private void OnDisable()
    {
        enter.Disable();
    }
   

    void Update()
    {
        if (enter.triggered)
        {
            if(Physics.Raycast(transform.position, transform.forward, out hit, 5f))
            {
                if (hit.rigidbody.CompareTag("SpaceShip"))
                {
                    spaceShip.GetComponent<Rigidbody>().isKinematic = false;
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        gameObject.GetComponent<SpaceMovement>().enabled = false;
                        playerInSpace.SetActive(false);
                        transform.GetChild(i).gameObject.SetActive(false);
                        spaceShipCam.enabled = true;
                        spaceShip.GetComponent<SpaceShipMovement>().enabled = true;
                        spaceShip.GetComponent<InteractSpaceShip>().enabled =true;
                    }
                }
                
            }
        }
    }

    private float interacting()
    {
        return enter.ReadValue<float>();
    }
    

    
}
