using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> objectsToSpawn = new List<GameObject>();
    public int numberOfSpawns = 5;
    public int spawnRadius;
   
    public void SpawnObjects()
    {
        if(objectsToSpawn.Count == 0)
        {
            Debug.Log("No items in list");
        }
        for (int i = 0; i < numberOfSpawns; i++)
        {
            GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Count)];
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            Instantiate(objectToSpawn,spawnPosition,Quaternion.identity);
        }
    }
    // Update is called once per frame
    private void Start()
    {
        SpawnObjects();
    }
}
