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
}
