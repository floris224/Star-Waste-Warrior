using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementinGrav : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private DefaultActionMap actionMap;
    private InputAction move;

    void Start()
    {
       
    }
    public void Awake()
    {
        actionMap = new DefaultActionMap();
        rb = GetComponent<Rigidbody>();
    }

    public void OnDisable()
    {
        
        move.Disable();
    }
    public void OnEnable()
    {
      
        move = actionMap.PlayerInForcefield.Move;
      

       
        
        move.Enable();
    }

    void Update()
    {
        Vector2 moveValue = Move();
        Vector3 movement = (new Vector3(-moveValue.x, 0, -moveValue.y));
        rb.velocity = movement * speed * Time.deltaTime;



    }


   
    private Vector2 Move()
    {
        return move.ReadValue<Vector2>();
    }
}

