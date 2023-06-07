using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrashValue : MonoBehaviour
{
    public int currentCapacity;
    public int maximumCapacity;
    public List<ValueTrash> collectedGarbage = new List<ValueTrash>();
    
   
    public void AddGarbage(ValueTrash garbage)
    {
        collectedGarbage.Add(garbage);
        currentCapacity += garbage.capacity;
    }

    public void RemoveGarbage(ValueTrash garbage)
    {
        collectedGarbage.Remove(garbage);
        currentCapacity -= garbage.capacity;
    }

    public int CalculateTotalValue()
    {
        int totalValue = 0;
        foreach (ValueTrash garbage in collectedGarbage)
        {
            totalValue += garbage.itemValue;
            
        }
       return totalValue;
    }
}


