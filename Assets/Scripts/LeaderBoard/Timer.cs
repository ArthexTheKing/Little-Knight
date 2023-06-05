using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    
    public float totalTime;
    public float timerValue;
    public TextMeshProUGUI timeText;

    void Start(){
        timerValue = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerValue > 0)
            timerValue -= Time.deltaTime;
        else
            timerValue = 0;
            DisplayTime(timerValue);
    }

    void DisplayTime(float timeToDisplay){
        if(timeToDisplay < 0)
            timeToDisplay = 0;
        //The Counter starts with the proper value and also communicate effectively the real amount of time left
        else if(timeToDisplay > 0){
            timeToDisplay += 1;
        }

            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
