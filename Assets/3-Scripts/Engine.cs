using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    ParticleSystem smokeEffect;
    bool isThrusting;
    private void Awake()
    {
        smokeEffect = GetComponentInChildren<ParticleSystem>();
    }
    void Update()
    {
        isThrusting = gameObject.GetComponentInParent<Movement>().isThrusting;
        if (isThrusting)
        {
            StartEngineSmoke();
        }
        else
        {
            StopEngineSmoke();
        }
    }

    void StartEngineSmoke()
    {
        smokeEffect.Play();
    }

    void StopEngineSmoke()
    {
        smokeEffect.Stop();  
    }
}
