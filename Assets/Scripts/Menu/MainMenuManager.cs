using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject gameO;
    public GameObject options;

    public void Start(){
        if(SceneManager.GetActiveScene().buildIndex == 2)
            OptionsToMenu();
        
        if(SceneManager.GetActiveScene().buildIndex == 0)
            options.SetActive(false);
    }
    public void Play(){
        print("Benvenuto giocatore!");
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void MenuToOptions(){
        gameO.SetActive(false);
        options.SetActive(true);
    }

    public void OptionsToMenu(){
        options.SetActive(false);
        gameO.SetActive(true);
    }

    public void ReturnToMainMenu(){
        print("Ritorno al menu principale");
        PauseMenu pm = this.GetComponent<PauseMenu>();
        pm.resumeGame();
        SceneManager.LoadScene("Main_Menu", LoadSceneMode.Single);
    }
}
