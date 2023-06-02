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
    
    public float rotationX;
    public float rotationSensX;
    public float rotationSensY;
    private Rigidbody rb;
    private DefaultActionMap actionMap;
    private InputAction interact;
    private InputAction rotate;
    private InputAction move;

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
        interact.Disable();
        rotate.Disable();
        
    }
    public void OnEnable()
    {
        interact = actionMap.PlayerInForcefield.Interact;
        rotate = actionMap.PlayerInForcefield.FirstPlayerCam;
        
        interact.Enable();
        rotate.Enable();
       
    }

    void Update()
    {

        Vector2 cursorPosition = Rotate();
        float rotationX = cursorPosition.x * mousSens * rotationSensX * Time.deltaTime;
        float rotationY = cursorPosition.y * mousSens * rotationSensY * Time.deltaTime;

        // Rotate the player body around the Y-axis
        playerBody.transform.Rotate(Vector3.up * rotationX);

        // Rotate the camera around the X-axis
        Vector3 cameraRotation = gameObject.transform.rotation.eulerAngles;
        float newCameraRotationX = cameraRotation.x - rotationY;
        newCameraRotationX = Mathf.Clamp(newCameraRotationX, 0f, 90f);
        gameObject.transform.rotation = Quaternion.Euler(newCameraRotationX, cameraRotation.y, cameraRotation.z);






    }


    private float Interact()
    {
        return interact.ReadValue<float>();
    }
    private Vector2 Rotate()
    {
        return rotate.ReadValue<Vector2>();
    }

}
