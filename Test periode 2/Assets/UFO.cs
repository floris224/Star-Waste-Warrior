using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    public float speed;
    public List<Transform> targets;
    public GameObject player;
    public GameObject spaceShip;
    public Transform ufo;
    private int transformIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ufo.position = Vector3.MoveTowards(ufo.position, targets[transformIndex].position, speed * Time.deltaTime);
        if(ufo.position == targets[transformIndex].position)
        {
            transformIndex++;
        }
    }
}
