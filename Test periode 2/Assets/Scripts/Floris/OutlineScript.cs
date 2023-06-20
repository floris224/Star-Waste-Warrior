using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineScript : MonoBehaviour
{
    public List <GameObject> trashGameObjectList = new List <GameObject>();
    public float range;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject offline in trashGameObjectList)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject trashGameObject in trashGameObjectList)
        {
            float distance = Vector3.Distance(transform.position, trashGameObject.transform.position);
            if(distance <= range)
            {
                trashGameObject.SetActive(true);
            }
            else
            {
                trashGameObject.SetActive(false);
            }
        }
    }
}
