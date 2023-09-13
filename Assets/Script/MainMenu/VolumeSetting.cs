using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSetting : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        LoadVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume()
    {
        float volume = volumeSlider.value;
        mixer.SetFloat("Volume", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("gameVolume", volume);
        LoadVolume();
    }

    void LoadVolume()
    {
        float volumeSet = PlayerPrefs.GetFloat("gameVolume");
        volumeSlider.value = volumeSet;
        AudioListener.volume = volumeSet;
    }
}
