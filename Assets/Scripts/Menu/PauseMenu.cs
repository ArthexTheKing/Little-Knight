using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private Canvas controlPanel;
    private bool isPaused;
    
    void Start()
    {
        controlPanel = GameObject.Find("Touch Control").GetComponent<Canvas>();
        pauseMenu.SetActive(false);
        controlPanel.enabled = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
            }   
        }
    }

    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        controlPanel.enabled = false;
        isPaused = true;
    }

    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        controlPanel.enabled = true;
        isPaused = false;
    }
}
