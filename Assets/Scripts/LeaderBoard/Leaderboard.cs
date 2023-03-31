using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour
{
    [SerializeField]
    private List<TextMeshProUGUI> names;
    [SerializeField]
    private List<TextMeshProUGUI> scores;
    public GameObject mainMenuButton;
    public static bool isSubmitted = false; 
    private string publicKey;
    private string[] badWords /*= {"cazz", "pisell", "pene", "merd", "sesso", "scroto",
     "testicol", "tett", "sborra", "squirt", "scemo", "deficiente", 
     "coglion", "peni", "bastardo", "froci", "negr", "mongoloid"}*/; 
    private void Start(){
        GetLeaderBoardKey();
        GetLeaderBoard();
    }
    public void GetLeaderBoard(){
        LeaderboardCreator.GetLeaderboard(publicKey, ((msg) => {
            int loopLenght = (msg.Length < names.Count) ? msg.Length : names.Count;
            for(int i = 0; i < loopLenght; i++){
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));
    }

    public void SetLeaderBoardEntry(string username, int score){
        LeaderboardCreator.UploadNewEntry(publicKey, username, 
            score, ((msg) => {
                //username.Substring(0,4);
                if(System.Array.IndexOf (badWords, username) != -1){
                    print("Devi inserire uno username valido");
                } 
                if(username == null){
                    print("Devi inserire uno username");
                }
                else isSubmitted = true;
                GetLeaderBoard();
        }));
    }

    private void GetLeaderBoardKey(){
        if(SceneManager.GetActiveScene().buildIndex == 4){
                publicKey = 
                "4ff04101b7d7df239bb75479624412523d1eb5321ca2d51a5ba94286da1a4f96";
        }
        else if(SceneManager.GetActiveScene().buildIndex == 5){
                publicKey = 
                "9df1e824b8157ed397b953f7cb6c5a9315d0658263f49931c77584852dc48e48";
        }
        else {
                publicKey = 
                "d1c504871f4a3f5f541a47cae9b14f813df4e609d8681a9c54126509a76422c6";
        }
    }

}
