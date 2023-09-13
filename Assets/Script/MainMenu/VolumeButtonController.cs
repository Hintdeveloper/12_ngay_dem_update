using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    public Button volumeButton;
    void Start()
    {
        volumeButton.onClick.AddListener(ToggleSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private bool soundOn = true;

    public void ToggleSound()
    {
        soundOn = !soundOn;
        AudioListener.volume = soundOn ? 1f : 0f; // ??t âm l??ng c?a toàn b? âm thanh trong game
    }
}
