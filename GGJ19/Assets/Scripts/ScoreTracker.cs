using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public int moodScore;
    public int gainedScore;
   

    // Start is called before the first frame update
    void Start()
    {
        moodScore = 0;
        gainedScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(List<GameObject> catlist)
    {
        moodScore = 0;
        foreach(var cat in catlist)
        {
            moodScore += cat.GetComponent<Block>().mood;
        }
    }

    public int GetScore()
    {
        return moodScore + gainedScore;
    }
}
