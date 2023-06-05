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
    
    void Awake()
    {
        actionMap = new DefaultActionMap();
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        move = actionMap.PlayerInForcefield.Move;
        mouseAction = actionMap.PlayerInForcefield.FirstPlayerCam;

        mouseAction.Enable();
        move.Enable();
    }

    void OnDisable()
    {
        mouseAction.Disable();
        move.Disable();
    }


    void Update()
    {
        // movement
        Vector2 moveValue = Move();
        Vector3 movement = new Vector3(-moveValue.x, 0f, -moveValue.y);
        rb.velocity = movement * speed * Time.deltaTime;


        
    }



   

    Vector2 Move()
    {
        return move.ReadValue<Vector2>();
    }
    
}