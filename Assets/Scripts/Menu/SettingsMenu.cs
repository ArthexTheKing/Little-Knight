using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    private float volume;
    [SerializeField]
    private GameObject muteIcon;
    [SerializeField]
    private GameObject volumeIcon;

    private void Start(){
        ChangeIcon();
    }
    
    public void SetVolume(float volume){
        audioMixer.SetFloat("volume", volume);
        ChangeIcon();
    }

    public void ChangeIcon(){
        audioMixer.GetFloat("volume", out volume);
        if(volume == -80){
            muteIcon.SetActive(true);
            volumeIcon.SetActive(false);
        }
        else{
            muteIcon.SetActive(false);
            volumeIcon.SetActive(true);
        }
    }
}
