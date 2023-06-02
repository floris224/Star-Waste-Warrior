using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Burst;
using UnityEngine;
using UnityEngine.InputSystem;
public class Look : MonoBehaviour
{
    public float mousSens;
    public Vector3 dir;
    public GameObject playerBody;

    public float rotationThreshold = 0.1f;

    public float rotationX;
    public float rotationSensX;
    public float rotationSensY;
    private Rigidbody rb;
    private DefaultActionMap actionMap;
    private InputAction rotate;


    void Start()
    {

    }
    public void Awake()
    {
        actionMap = new DefaultActionMap();
        rb = playerBody.GetComponent<Rigidbody>();
    }

    public void OnDisable()
    {

        rotate.Disable();

    }
    public void OnEnable()
    {

        rotate = actionMap.PlayerInForcefield.FirstPlayerCam;

        rotate.Enable();

    }

    void Update()
    {
        /*
        Vector2 rotateInput = Rotate();  // Assuming this method returns the desired rotation values

        float screenWidthHalf = Screen.width / 2f;
        float screenHeightHalf = Screen.height / 2f;
        Vector2 cursorPositionFromCenter = new Vector2(-(screenWidthHalf - rotateInput.x), -(screenHeightHalf - rotateInput.y));

        float rotationX = Mathf.Clamp(cursorPositionFromCenter.x / screenWidthHalf, -1f, 1f);
        float rotationY = Mathf.Clamp(cursorPositionFromCenter.y / screenHeightHalf, -1f, 1f);

        Vector2 rotation = new Vector2(rotationX, rotationY);
        
        Vector3 rotationXForce = new Vector3(-rotation.y, 0f, 0f);
        rb.AddTorque(rotationXForce * rotationSensX * Time.deltaTime);

        Vector3 rotationYForce = new Vector3(0f, rotation.x, 0f);
        rb.AddTorque(rotationYForce * rotationSensY * Time.deltaTime);
        */
        Vector2 rotateInput = Rotate();

        if (rotateInput.magnitude > rotationThreshold)
        {
            float rotationX = rotateInput.y * rotationSensX;
            float rotationY = rotateInput.x * rotationSensY;

            Vector3 rotationXForce = new Vector3(-rotationX, 0f, 0f);
            rb.AddTorque(rotationXForce * Time.deltaTime);

            Vector3 rotationYForce = new Vector3(0f, rotationY, 0f);
            rb.AddTorque(rotationYForce * Time.deltaTime);
        }

    }
    public Vector2 Rotate()
    {
        return rotate.ReadValue<Vector2>();
    }
}
