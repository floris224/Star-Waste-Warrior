using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public Animator animator;
    public float timeStamp;

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("PlayerInGrav"))
        {
            if (Time.time > timeStamp)
            {
                animator.SetTrigger("Enter");
                timeStamp = Time.time + 5;
            }
        }
    }
}
