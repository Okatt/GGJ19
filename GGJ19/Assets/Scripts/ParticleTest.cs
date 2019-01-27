using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTest : MonoBehaviour
{
    public new ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("setting em.enabled to true");
            particleSystem.Play();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("setting em.enabled to false");
            particleSystem.Stop();
        }
    }
}
