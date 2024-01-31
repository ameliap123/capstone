using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioVolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }
    public void changeVolume()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
        PlayerPrefs.Save();
    }
    private void Update()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }
}
