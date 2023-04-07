using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leaderboard_Move_Scene : MonoBehaviour
{
    public int sceneBuildIndex;
    public ScoreCalculator sc;
    public GameObject canvas;
    public GameObject eventSystem;
    private void OnTriggerEnter2D(Collider2D other){
        print("Trigger Entered");

        if(other.tag == "Player"){
            print("Switching Scene to: " + sceneBuildIndex);
            sc.finalizingScore();
            DisableUI();
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Additive);
            SceneManager.MoveGameObjectToScene(eventSystem, SceneManager.GetSceneByBuildIndex(sceneBuildIndex));
        }
    }

    private void DisableUI(){
        canvas.SetActive(false);
    }

    
}
