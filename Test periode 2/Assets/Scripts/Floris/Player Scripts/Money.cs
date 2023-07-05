using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int geld;

    public int GetMoney()
    {
        return geld;
    }

    public void SetMoney(int amount)
    {
        geld = amount;
    }
}
