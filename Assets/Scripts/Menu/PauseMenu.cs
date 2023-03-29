using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject mainMenu;
    public static bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.R)){
            if(isPaused){
                resumeGame();
            }
            
        }
        
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(!isPaused){
                pauseGame();
            }
            
        }
        
    }
    public void pauseGame(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        mainMenu.SetActive(false);
        isPaused = true;
    }

    public void resumeGame(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        mainMenu.SetActive(true);
        isPaused = false;
    }
}
