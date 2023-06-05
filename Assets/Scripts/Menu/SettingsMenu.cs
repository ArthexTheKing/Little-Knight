using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    private float volume;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        Debug.Log("Closing Application");
        Application.Quit();
    }
    
    public void SetVolume(float volume){
        audioMixer.SetFloat("volume", volume);
    }

}
