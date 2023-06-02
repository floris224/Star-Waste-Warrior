using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
public class Look : MonoBehaviour
{
    public float mousSens;
    public Vector3 dir;
    public GameObject playerBody;
    public float speed;
    private Rigidbody rb;
    private DefaultActionMap actionMap;
    private InputAction interact;
    private InputAction rotate;
    private InputAction move;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   
    }
    public void Awake()
    {
        actionMap = new DefaultActionMap();
        rb = GetComponent<Rigidbody>();
    }

    public void OnDisable()
    {
        interact.Disable();
        rotate.Disable();
        move.Disable();
    }
    public void OnEnable()
    {
        interact = actionMap.PlayerInForcefield.Interact;
        move = actionMap.PlayerInForcefield.Move;
        rotate = actionMap.PlayerInForcefield.FirstPlayerCam;
        
        interact.Enable();
        rotate.Enable();
        move.Enable();
    }

    void Update()
    {
        Vector2 moveValue = Move();
        Vector3 movement = (new Vector3(moveValue.x, 0, moveValue.y));
        rb.velocity = movement * Time.deltaTime;

       
    }
    private void FixedUpdate()
    {
        
        
    }

    private float Interact()
    {
        return interact.ReadValue<float>();
    }
    private Vector2 Rotate()
    {
        return rotate.ReadValue<Vector2>();
    }
    private Vector2 Move()
    {
        return move.ReadValue<Vector2>();
    }
}
