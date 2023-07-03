using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectSpawnerEnviromental : MonoBehaviour
{

    public List<GameObject> objectsToSpawn = new List<GameObject>();
    public int numberOfSpawns = 5;
    public int spawnRadius;

    public void SpawnObjects()
    {
        if (objectsToSpawn.Count == 0)
        {
            Debug.Log("No items in list");
        }
        for (int i = 0; i < numberOfSpawns; i++)
        {
            GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Count)];
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            float scale = Random.Range(50f, 100f);
            spawnedObject.transform.localScale = new Vector3(scale, scale);


        }
    }
    // Update is called once per frame
    private void Start()
    {
        SpawnObjects();
    }
}
