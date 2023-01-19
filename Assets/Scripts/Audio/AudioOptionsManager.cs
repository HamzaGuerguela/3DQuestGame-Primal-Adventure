using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.Audio;

public class AudioOptionsManager : MonoBehaviour
{
    public static float MusicVolume { get; private set; }
    public static float SoundEffectsVolume { get; private set; }

    public AudioMixer audioMixer;

    [SerializeField] private TextMeshProUGUI musicSliderText;
    [SerializeField] private TextMeshProUGUI soundEffectsSliderText;
    
    public void OnMusicSliderValueChange(float value)
    {
        MusicVolume = value;
        
        musicSliderText.text = ((int)(value * 100)).ToString();
        audioMixer.SetFloat("Music Volume", Mathf.Log10(value) * 20);
    }
    public void OnSoundEffectsSliderValueChange(float value)
    {
        SoundEffectsVolume = value;
        
        soundEffectsSliderText.text = ((int)(value * 100)).ToString();
        audioMixer.SetFloat("Sound Effects Volume", Mathf.Log10(value) * 20);
    }
}

