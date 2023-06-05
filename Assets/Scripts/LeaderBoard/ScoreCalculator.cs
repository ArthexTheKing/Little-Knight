using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCalculator : MonoBehaviour
{
    private int score = 0;
    public Timer timer;
    private float totalTime;
    private int timeScore;
    public TextMeshProUGUI highScore;
    [SerializeField] private GameObject ObjectPreFab;

    //factors
    [SerializeField]
    public float timeScoreFactor;

    // Start is called before the first frame update
    void Start()
    {
        totalTime = timer.totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        scoreUpdate();
        highScore.text = string.Format("{0:D5}", score);
    }

    public void finalizingScore(){
        timeScore = Mathf.RoundToInt((timer.timerValue) * timeScoreFactor);
        score += timeScore;
        PlayerPrefs.SetInt("score", score);
    }

    void scoreUpdate(){
        score = Global.coinScore + Global.enemyScore;
    }
}
