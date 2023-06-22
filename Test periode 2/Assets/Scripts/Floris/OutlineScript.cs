using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineScript : MonoBehaviour
{
    public string[] tags;
    public List<GameObject> childSmall = new List<GameObject>();

    
 
    private void OnTriggerEnter(Collider other)
    {
        if (tagMatch(other.gameObject.tag))
        {
            if (!childSmall.Contains(other.gameObject))
            {
                childSmall.Add(other.gameObject);
                ChildGoTrue(other.gameObject, true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (tagMatch(other.gameObject.tag))
        {
            if (childSmall.Contains(other.gameObject))
            {
                childSmall.Remove(other.gameObject);
                ChildGoTrue(other.gameObject, false);
            }
        }
    }

    private bool tagMatch(string tag)
    {
        foreach(string goodTag in tags)
        {
            if(tag == goodTag)
            {
                return true;
            }
        }
        return false;
    }

    private void ChildGoTrue(GameObject parent , bool activate)
    {
        foreach(Transform child in parent.transform)
        {
            child.gameObject.SetActive(activate);
        }
    }
}
