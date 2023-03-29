using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI inputScore;
    [SerializeField]
    private TMP_InputField inputName;
    private int sceneBuildIndex;
    public UnityEvent<string, int> submitScoreEvent;
    public GameObject mainMenuButton;
    public void SubmitScore(){
        submitScoreEvent.Invoke(inputName.text, int.Parse(inputScore.text));
        if(Leaderboard.isSubmitted)
            DisablingSubmitingScores();
    }

    public void DisablingSubmitingScores(){
        gameObject.SetActive(false);
    }

    public void MainMenu(){
        SceneManager.LoadScene("Main_Menu", LoadSceneMode.Single);
    }

    public void SceneLoader(){
        
        if(SceneManager.GetActiveScene().buildIndex == 0)
            sceneBuildIndex = 2;
        else if(SceneManager.GetActiveScene().buildIndex == 3)
            sceneBuildIndex = 4;
        else if(SceneManager.GetActiveScene().buildIndex == 4)
            sceneBuildIndex = 5;
        else if(SceneManager.GetActiveScene().buildIndex == 5)
            sceneBuildIndex = 6;
        else if(SceneManager.GetActiveScene().buildIndex == 6)
            sceneBuildIndex = 2;
        print("Switching Scene to: " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}
