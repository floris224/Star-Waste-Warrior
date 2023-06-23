using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Conversation", menuName = "Scriptable Objects/Conversation", order = 1)]

public class SoConvo : ScriptableObject
{
    public string[] npcSays, youSay;
}

