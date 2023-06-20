using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider musicSlider, sfxSlider;
    public AudioMixer music, sfx;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 0.8f);      
        }
       
        if (!PlayerPrefs.HasKey("sfxVolume"))
        {
            PlayerPrefs.SetFloat("sfxVolume", 0.8f);
        }
        Load();
    }

    public void ChangeVolume()
    {
        music.Equals(musicSlider.value);
        sfx.Equals(sfxSlider.value);
        Save();

    }

    private void Load()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        Debug.Log(PlayerPrefs.GetFloat("sfxVolume"));

    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("sfxVolume", sfxSlider.value);
        Debug.Log(PlayerPrefs.GetFloat("sfxVolume"));
    }
}
