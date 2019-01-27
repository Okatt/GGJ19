using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreWriter : MonoBehaviour
{
    public TextMeshProUGUI scoreDisplay;

    private int score;
    private int newScore;

    private ScoreTracker scoreTracker;

    void Start()
    {
        score = 0;
        scoreDisplay = GetComponent<TextMeshProUGUI>();
        scoreTracker = GetComponentInParent<GUI>().blockDropper.GetComponentInParent<BlockDropper>().scoreTracker.GetComponent<ScoreTracker>();
    }

    // Update is called once per frame
    void Update()
    {     
        newScore = scoreTracker.GetScore();
        if (score != newScore)
        {
            score = newScore;
            scoreDisplay.text = score.ToString();
        }

    }
}
