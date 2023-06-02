using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject spaceshipGoToPosition;
    public GameObject spaceship;
    private bool isMoving;
    public float timer;
    public float moveToWardsSpeed;
    public SpaceShipMovement _ship;

    public float[] pp;


    
    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        timer = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isMoving)
        {
            float step = moveToWardsSpeed * Time.deltaTime;
            spaceship.transform.position = Vector3.MoveTowards(spaceship.transform.position, spaceshipGoToPosition.transform.position, step);
        }

        if (Vector3.Distance(spaceship.transform.position, spaceshipGoToPosition.transform.position) <= 0.01f)
        {
            timer += Time.deltaTime;
            if (timer >= 4f)
            {

                spaceship.GetComponent<SpaceShipMovement>().enabled = true;
                timer -= timer;
                isMoving = false;
            }
        }


       
        
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpaceShip"))
        {

            other.GetComponent<SpaceShipMovement>().enabled = false;


            isMoving = true;
            Debug.Log("" + other.transform.name);
        }

    }
}
