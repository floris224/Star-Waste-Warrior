using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractSpaceShip : MonoBehaviour
{
    public GameObject spawnPoint;
    private DefaultActionMap actionmap;
    private InputAction interact;
    public GameObject playerSpace;
    public Camera camSpaceShip;
    // Start is called before the first frame update
    private void Awake()
    {
        actionmap = new DefaultActionMap();

    }
    private void OnEnable()
    {
        interact = actionmap.SpaceShip.Interact;
        interact.Enable();

    }
    private void OnDisable()
    {
        interact.Disable();
    }
   

    // Update is called once per frame
    void Update()
    {
        if (interact.triggered)
        {
            gameObject.GetComponent<SpaceShipMovement>().enabled = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            playerSpace.SetActive(true);
            playerSpace.transform.position = spawnPoint.transform.position;
            for (int i = 0; i < playerSpace.transform.childCount; i++)
            {
                playerSpace.GetComponent<SpaceMovement>().enabled = true;
                playerSpace.transform.GetChild(i).gameObject.SetActive(true);
                camSpaceShip.GetComponent<Camera>().enabled = false;
               

            }

        }

    }
    private float interactInput()
    {
        return interact.ReadValue<float>();
    }
}
