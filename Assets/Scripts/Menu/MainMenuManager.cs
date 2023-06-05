using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject options;
    public GameObject quitMenu;

    public void Play()
    {
        print("Benvenuto giocatore!");
        SceneManager.LoadScene("Livello 1", LoadSceneMode.Single);
    }

    public void MenuToOptions()
    {
        pauseMenu.SetActive(false);
        options.SetActive(true);
    }

    public void OptionsToMenu()
    {
        options.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        print("Ritorno al menu principale");
        PauseMenu pm = this.GetComponent<PauseMenu>();
        pm.resumeGame();
        SceneManager.LoadScene(0);
    }

    public void WantToQuit()
    {
        pauseMenu.SetActive(false);
        quitMenu.SetActive(true);
    }

    public void Quit(){
        ReturnToMainMenu();
    }

    public void DontQuit(){
        quitMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
