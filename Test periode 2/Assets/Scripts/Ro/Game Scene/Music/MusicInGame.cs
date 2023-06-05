using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicInGame : MonoBehaviour
{
    public int numberOfAliensChasing;
    public bool battleMusic, backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfAliensChasing > 0)
        {
            battleMusic = true;
        }
        else
        {
            battleMusic = false;
        }
        if (battleMusic == true)
        {
            backgroundMusic = false;
        }
        else
        {
            backgroundMusic = true;
        }
    }
}
