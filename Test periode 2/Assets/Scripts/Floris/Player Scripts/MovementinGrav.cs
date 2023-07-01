using UnityEngine.InputSystem;
using UnityEngine;
using Unity.Mathematics;

public class MovementinGrav : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private DefaultActionMap actionMap;
    private InputAction move;
    private InputAction mouseAction;
    public Transform camRotation;
    void Awake()
    {
        actionMap = new DefaultActionMap();
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        move = actionMap.PlayerInForcefield.Move;
        move.Enable();
    }

    void OnDisable()
    {
        move.Disable();
    }


    void Update()
    {
        // movement
        Vector2 moveValue = Move();
        Vector3 forward = camRotation.forward;
        Vector3 right = camRotation.right;
        forward.y = 0f;
        right.y = 0f;
        Vector3 movement = (right.normalized * moveValue.x + forward.normalized * moveValue.y);
        rb.velocity = movement * speed * Time.deltaTime;
    }



   

    Vector2 Move()
    {
        return move.ReadValue<Vector2>();
    }
    
}