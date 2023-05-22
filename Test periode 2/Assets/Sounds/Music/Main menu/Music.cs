using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource intro, loop;
    // Start is called before the first frame update
    void Start()
    {
        intro.enabled = true;
        loop.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!intro.isPlaying)
        {
            intro.enabled = false;
            loop.enabled = true;
        }
    }
}
