using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    public TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        score.text = string.Format("{000000}", PlayerPrefs.GetInt("score"));
    }
}
