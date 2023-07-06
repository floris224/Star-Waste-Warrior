using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    public float speed;
    public List<Transform> targets;
    public GameObject spaceShip, laserPoint;
    public Transform ufo;
    public Transform inRange;
    public ParticleSystem particleEffect;
    public Transform particleSpawnPoint;
    public float hangDuration = 5f;
    public bool isHanging = false;
    public float hangTimer = 0f;
    public int transformIndex = 0;
    public float ufoHealth;
    public RaycastHit hit;
    public float range;
    public ParticleSystem ufoExplosion;
    private VuilniswagenCapaciteit capaciteit;
    private List<int> spaceshipSlots;

    // Start is called before the first frame update
    void Start()
    {
        capaciteit = FindObjectOfType<VuilniswagenCapaciteit>();
        spaceshipSlots = capaciteit.spaceshipSlots;
    }

    // Update is called once per frame
    void Update()
    {
        UfoDied();
        if (Vector3.Distance(spaceShip.transform.position, ufo.transform.position) <= range)
        {
            if (isHanging)
            {
                
                hangTimer += Time.deltaTime;

                if (hangTimer >= hangDuration)
                {
                   
                    isHanging = false;
                    particleEffect.Stop();
                    hangTimer = 0f;
                    MovementUfo();
                }
            }
            else
            {
                ufo.position = Vector3.MoveTowards(ufo.transform.position, inRange.transform.position, speed * Time.deltaTime);
                Debug.DrawRay(laserPoint.transform.position, -laserPoint.transform.up, Color.red);
                if (Physics.Raycast(laserPoint.transform.position, -laserPoint.transform.up, out hit, 200))
                {
                    Debug.Log(hit.transform.name);

                    if (hit.transform.tag == "SpaceShip")
                    {
                      
                        isHanging = true;
                        particleEffect.Play();
                        particleEffect.transform.position = particleSpawnPoint.position;

                        
                        if (spaceshipSlots.Count > 0)
                        {
                            spaceshipSlots.RemoveAt(spaceshipSlots.Count - 1);
                        }
                    }
                }
            }
        }
        else
        {
            MovementUfo();
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
        if (ufoHealth <= 1)
        {
            ufoExplosion.Play();
            Destroy(gameObject);
        }
    }
}