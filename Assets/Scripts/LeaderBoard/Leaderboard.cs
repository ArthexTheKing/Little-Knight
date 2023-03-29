using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;

public class Leaderboard : MonoBehaviour
{
    [SerializeField]
    private List<TextMeshProUGUI> names;
    [SerializeField]
    private List<TextMeshProUGUI> scores;
    public GameObject mainMenuButton;
    public static bool isSubmitted = false; 
    private string publicKey = 
        "d1c504871f4a3f5f541a47cae9b14f813df4e609d8681a9c54126509a76422c6";
    private string[] badWords = {"cazz", "pisell", "pene", "merd", "sesso", "scroto",
     "testicol", "tett", "sborra", "squirt", "scemo", "deficiente", 
     "coglion", "peni", "bastardo", "froci", "negr", "mongoloid"}; 
    private void Start(){
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

}
