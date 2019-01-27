using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadMood : MonoBehaviour
{
    public new ParticleSystem particleSystem;

    void Awake()
    {
        Debug.Log("Getting ParticleSystem");
        particleSystem = GetComponent<ParticleSystem>();
    }

    public void InsertSadness()
    {
        particleSystem.Play();
    }

    public void ForceStopAnimation()
    {
        particleSystem.Stop();
    }
}
