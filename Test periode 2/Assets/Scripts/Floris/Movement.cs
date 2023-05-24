using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float forwardSpeed = 25f, strafeSpeed = 5f;
    private float activeForwardSpeed, activeStrafeSpeed;
    private float forwardsAccel = 2.5f, strafeAccel = 2f;
    public Vector2 lookInput, screenCenter, mouseDis;
    public float lookRotSpeed;
    public Vector3 rotationPosStart;
    public Vector3 reset;
    public float maxRotSpeed;

    private float inputTimer;
    public const float inputResetTime = 6f;

    // Start is called before the first frame update
    void Start()
    {
        screenCenter.x = Screen.width * 0.5f;
        screenCenter.y = Screen.height * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDis.x = (lookInput.x - screenCenter.x) / screenCenter.x;
        mouseDis.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        transform.Rotate(-mouseDis.y * lookRotSpeed * Time.deltaTime, mouseDis.x * lookRotSpeed * Time.deltaTime, 0f, Space.Self);

        float targetForwardSpeed = Input.GetAxisRaw("Vertical") * forwardSpeed * forwardsAccel;
        float targetStrafeSpeed = Input.GetAxisRaw("Horizontal") * strafeSpeed * strafeAccel;

        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, targetForwardSpeed, Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, targetStrafeSpeed, Time.deltaTime);

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        transform.position += transform.right * activeStrafeSpeed * Time.deltaTime;

        if (Mathf.Abs(targetForwardSpeed) < 0.01f && Mathf.Abs(targetStrafeSpeed) < 0.01f)
        {
            inputTimer += Time.deltaTime;
            if (inputTimer >= inputResetTime)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.identity, maxRotSpeed);
                if (transform.rotation == Quaternion.Euler(1, 0, 1))
                {
                    inputTimer = 0f;
                }

            }
        }
        else
        {
            inputTimer = 0f;
        }

    }


}

