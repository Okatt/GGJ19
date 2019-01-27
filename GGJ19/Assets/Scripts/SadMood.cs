using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadMood : MonoBehaviour
{
    public new ParticleSystem particleSystem;

    void Awake()
    {
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
