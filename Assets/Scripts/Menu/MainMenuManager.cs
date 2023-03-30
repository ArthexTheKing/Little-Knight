using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mMenu;
    public GameObject options;

    public void Start(){
        int index = SceneManager.GetActiveScene().buildIndex;
        if(index == 2 || index == 7 || index == 6)
            OptionsToMenu();
        
        if(index == 0 || index == 3 || index == 4 || index == 5 || index == 1)
            options.SetActive(false);
    }
    public void Play(){
        print("Benvenuto giocatore!");
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void MenuToOptions(){
        mMenu.SetActive(false);
        options.SetActive(true);
    }

    public void OptionsToMenu(){
        options.SetActive(false);
        mMenu.SetActive(true);
    }

    public void ReturnToMainMenu(){
        print("Ritorno al menu principale");
        PauseMenu pm = this.GetComponent<PauseMenu>();
        pm.resumeGame();
        SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);
    }
}
