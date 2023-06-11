using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicInGame : MonoBehaviour
{
    public int numberOfAliensChasing;
    public bool battle;
    public AudioClip defaultClip;
    public AudioSource inGameAudio, battleAudio;
    // Start is called before the first frame update
    void Start()
    {
        inGameAudio.Play();
        battleAudio.Play();
        battleAudio.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (numberOfAliensChasing > 0)
        {
            if (battle == false)
            {
                SwapTrack();
            }
            battle = true;
        }
        else
        {
            if (battle == true)
            {
                SwapTrack();
            }
            battle = false;
        }
    }
    public void SwapTrack()
    {
        StopAllCoroutines();

        StartCoroutine(FadeTrack());
    }
    private IEnumerator FadeTrack()
    {
        float timeToFade = 4f;
        float timeElapsed = 0;
        if (battle == true)
        {
            

            while (timeElapsed < timeToFade)
            {
                battleAudio.volume = Mathf.Lerp(0.2f, 0, timeElapsed / timeToFade);
                inGameAudio.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            
        }
        else
        {
            

            while (timeElapsed < timeToFade)
            {
                inGameAudio.volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
                battleAudio.volume = Mathf.Lerp(0, 0.2f, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            
        }
    }
}
