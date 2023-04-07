using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject options;
    public GameObject quitMenu;

    public void Start(){
        int index = SceneManager.GetActiveScene().buildIndex;
        quitMenu.SetActive(false);
        if(index == 2 || index == 7 || index == 6)
            OptionsToMenu();
        
        if(index == 0 || index == 3 || index == 4 || index == 5 || index == 1)
            options.SetActive(false);
    }
    public void Play(){
        print("Benvenuto giocatore!");
        SceneManager.LoadScene("Livello 1", LoadSceneMode.Single);
    }

    public void MenuToOptions(){
        pauseMenu.SetActive(false);
        options.SetActive(true);
    }

    public void OptionsToMenu(){
        options.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void ReturnToMainMenu(){
        print("Ritorno al menu principale");
        PauseMenu pm = this.GetComponent<PauseMenu>();
        pm.resumeGame();
        SceneManager.LoadScene("Main_Menu", LoadSceneMode.Single);
    }

    public void WantToQuit(){
        pauseMenu.SetActive(false);
        quitMenu.SetActive(true);
    }

    public void Quit(){
        if(SceneManager.GetActiveScene().buildIndex == 2){
            print("Sei uscito con successo dall'applicazione");
            Application.Quit();
            
        }
            
        else ReturnToMainMenu();
    }

    public void DontQuit(){
        quitMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
