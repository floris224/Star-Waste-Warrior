using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Trash Database", menuName = "Trash Database")]
public class TrashDatabase : ScriptableObject
{
    public ValueTrash[] trashValue;
}
