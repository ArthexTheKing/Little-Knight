using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage_Loader : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
        print("Trigger Entered");

        if(other.tag == "Player"){
            print("Switching Scene to: " + 1);
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
        }
    }

    
}
