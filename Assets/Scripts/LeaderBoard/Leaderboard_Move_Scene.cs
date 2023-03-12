using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leaderboard_Move_Scene : MonoBehaviour
{
    public int sceneBuildIndex;
    public ScoreCalculator sc;
    private void OnTriggerEnter2D(Collider2D other){
        print("Trigger Entered");

        if(other.tag == "Player"){
            print("Switching Scene to: " + sceneBuildIndex);
            sc.finalizingScore();
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
