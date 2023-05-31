using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject spaceshipGoToPosition;
    public GameObject spaceship;
    private bool isMoving;
    public float timer;

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
            spaceship.transform.position = Vector3.MoveTowards(spaceship.transform.position, spaceshipGoToPosition.transform.position, Time.deltaTime);
        }

        if (isMoving && spaceship.transform.position == spaceshipGoToPosition.transform.position)
        {
            timer += Time.deltaTime;

            if (timer >= 4f)
            {

                spaceship.GetComponent<SpaceShip>().enabled = true;
                timer = 0f;
                isMoving = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Spaceship"))
        {

            spaceship.GetComponent<SpaceShip>().enabled = false;


            isMoving = true;
        }

    }
}
