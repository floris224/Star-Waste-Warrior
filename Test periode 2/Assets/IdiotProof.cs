using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdiotProof : MonoBehaviour
{
    public PaymentManager paymentManager;
    public GameObject playerGrav;

    public void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "PlayerInGrav")
        {
            paymentManager.HandlePayment();
            playerGrav.GetComponent<MovementinGrav>().ResetPosition();
        }
    }
}
