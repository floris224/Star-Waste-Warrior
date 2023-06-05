using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Trash Item", menuName = "Trash Item")]
public class ValueTrash : ScriptableObject
{
    public string itemName;
    public int itemValue;
    public int capacity;
    
}
