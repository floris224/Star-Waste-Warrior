using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicInGame : MonoBehaviour
{
    public int numberOfAliensChasing;
    public bool battle, background;
    public AudioClip inGameMusic, inBattleMusic, currentClip;
    public AudioSource musicAudio;
    // Start is called before the first frame update
    void Start()
    {
        musicAudio.Play();
        battle = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (numberOfAliensChasing > 0)
        {
            if (battle == false)
            {
                musicAudio.clip = inBattleMusic;
                musicAudio.Play();
            }
            battle = true;
        }
        else
        {
            if (battle == true)
            {
                musicAudio.clip = inGameMusic;
                musicAudio.Play();
            }
            battle = false;
            musicAudio.clip = inGameMusic;
        }
    }
}
