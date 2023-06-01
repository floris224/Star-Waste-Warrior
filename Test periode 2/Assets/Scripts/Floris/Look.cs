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
    float rotY;
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
        float move = Move();
        rb.AddForce(new Vector3)

        /*
                // defineren van de vector3 over welke as hij zal moeten draaien
                dir = new Vector3(0, mouseX, 0);
                playerBody.transform.Rotate(dir * mousSens * Time.deltaTime);

               // defineren over welke as de camera moet draaien & het clampen van de rotatie.
                rotY += mouseY * mousSens * Time.deltaTime;
                rotY = Mathf.Clamp(rotY, -90, 90);
                Vector3 e = transform.eulerAngles;
                e.x = -rotY;
                transform.eulerAngles = e;
               */
    }
    private void FixedUpdate()
    {
        float moveValue = Move();
        rb.AddForce(new Vector3(moveValue.x))
    }

    private float Interact()
    {
        return interact.ReadValue<float>();
    }
    private Vector2 Rotate()
    {
        return rotate.ReadValue<Vector2>();
    }
    private Vector3 Move()
    {
        return move.ReadValue<Vector3>();
    }
}
