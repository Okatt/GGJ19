using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyMood : MonoBehaviour
{
    public new ParticleSystem particleSystem;
    
    void Awake()
    {
        Debug.Log("Getting ParticleSystem");
        particleSystem = GetComponent<ParticleSystem>();
    }

    public void InsertHappiness()
    {
        particleSystem.Play();
    }

    public void ForceStopAnimation()
    {
        particleSystem.Stop();
    }
    
}
