using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    public float speed;
    public List<Transform> targets;
    public GameObject player;
    public GameObject spaceShip, laserPoint;
    public Transform ufo;
    public Transform inRange;
    public RaycastHit hit;
    public GameObject particleEffect;
    public Transform particleSpawnPoint;
    public int transformIndex = 0, ufoHealth;
    public float particleDuration = 3f;
    public float particleTimer = 0f;
    public bool isParticleActive = false;
    public TeleportGun teleportGun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(spaceShip.transform.position, ufo.transform.position) <= 10)
        {
            ufo.position = Vector3.MoveTowards(ufo.transform.position, inRange.transform.position, speed * Time.deltaTime);
            if(Physics.Raycast(laserPoint.transform.position,-laserPoint.transform.up,out hit , 10))
            {
                if(hit.transform.tag == "VuilniswagenCapaciteit")
                {
                    if (!isParticleActive)
                    {
                        particleTimer = 0;
                        isParticleActive = true;
                    }
                    if (particleTimer >= particleDuration)
                    {
                        particleEffect.SetActive(true);
                        particleEffect.transform.position = particleSpawnPoint.position;
                        for (int i = teleportGun.spaceshipSlots.Count - 1; i >= 0; i--)
                        {
                            teleportGun.spaceshipSlots.RemoveAt(i);
                        }
                    }
                }
                else
                {
                    particleEffect.SetActive(false);
                    isParticleActive = false;
                    particleTimer = 0f;
                    
                }
            }
        }
        else
        {
            MovementUfo();
        }
       
        if (isParticleActive)
        {
            particleTimer += Time.deltaTime;
        }
    }
    
    
    
    public void MovementUfo()
    {
        ufo.position = Vector3.MoveTowards(ufo.position, targets[transformIndex].position, speed * Time.deltaTime);

        if (ufo.position == targets[transformIndex].position)
        {
            int randomIndex = Random.Range(0, targets.Count);
            transformIndex = randomIndex;
        }
    }
    public void UfoDied()
    {
        if(ufoHealth <= 1)
        {
            Destroy(ufo);
        }
    }
}
