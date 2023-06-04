using UnityEngine.InputSystem;
using UnityEngine;

public class MovementinGrav : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private DefaultActionMap actionMap;
    private InputAction move;
    private InputAction mouseAction;
    public float rotationX;
    public float rotationY;

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

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector2 moveValue = Move();
        Vector3 movement = new Vector3(-moveValue.x, 0f, -moveValue.y);
        rb.velocity = movement * speed * Time.deltaTime;

        Vector2 cursorPosition = CursorPosition();
        float screenWidthHalf = Screen.width * 0.5f;
        float screenheightHalf = Screen.height * 0.5f;

        Vector2 cursorPositionFromCenter = cursorPosition - new Vector2(screenWidthHalf, screenheightHalf);
        rotationX = Mathf.Clamp(cursorPositionFromCenter.x / screenWidthHalf, -1f, 1f);
        rotationY = Mathf.Clamp(cursorPositionFromCenter.y / screenheightHalf, -1f, 1f);

        if (Mathf.Abs(cursorPositionFromCenter.x) < 1f)
            rotationX = 0f;

        if (Mathf.Abs(cursorPositionFromCenter.y) < 1f)
            rotationY = 0f;

        Vector3 rotationXForce = new Vector3(-rotationY, 0f, 0f);
        rb.AddTorque(rotationXForce * rotationX * Time.deltaTime);

        Vector3 rotationYForce = new Vector3(0f, rotationX, 0f);
        rb.AddTorque(rotationYForce * rotationY * Time.deltaTime);

        Debug.Log(rotationX);
        Debug.Log(rotationY);
    }

    Vector2 CursorPosition()
    {
        
        return mouseAction.ReadValue<Vector2>();
    }

    Vector2 Move()
    {
        return move.ReadValue<Vector2>();
    }
}