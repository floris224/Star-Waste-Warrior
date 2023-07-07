using UnityEngine.InputSystem;
using UnityEngine;
using Unity.Mathematics;
using UnityEngine.EventSystems;

public class MovementinGrav : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private DefaultActionMap actionMap;
    private InputAction movementZ, movementX;
    private InputAction mouseAction;
    public Transform camRotation;
    public AudioSource footstep;
    private bool footstepPlaying;
    public Transform spawnPoint;
    void Awake()
    {
        actionMap = new DefaultActionMap();
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
         movementX= actionMap.PlayerInForcefield.LeftRight;
         movementZ= actionMap.PlayerInForcefield.ForwardsBackwards;
         movementX.Enable();
         movementZ.Enable();
    }

    void OnDisable()
    {
        movementZ.Disable();
        movementX.Disable();
    }


    void Update()
    {
        if (rb.velocity.magnitude > 0.1f)
        {
            if (footstepPlaying == false)
            {
                footstep.Play();
                footstepPlaying = true;
            }
           
        }
        else
        {
            footstep.Stop();
            footstepPlaying = false;
        }
        Vector3 cameraForward = camRotation.rotation * Vector3.forward;
        cameraForward.y = 0f;

        float forwards = ForwardsBackwards();
        Vector3 moveForce = cameraForward * -forwards;
        

        float leftRight = LeftRight();
        moveForce += camRotation.right * leftRight;
        rb.velocity = moveForce.normalized * speed;

        
    }

    public void ResetPosition()
    {
        gameObject.transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;
    }




    public float LeftRight()
    {
        return movementX.ReadValue<float>();
    }
    
    public float ForwardsBackwards()
    {
        return movementZ.ReadValue<float>();
    }
}