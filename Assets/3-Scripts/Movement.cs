using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 600f;
    [SerializeField] AudioClip thrustAudio;
    Rigidbody rb;
    AudioSource audioSource;
    new Transform transform;

    public bool isThrusting;

    bool isAlive;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        transform = GetComponent<Transform>();


    }    
    void Update()
    {
        ProcessThrust();
        ProcessRotation();

      
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else if (!Input.GetKey(KeyCode.Space))
        {
            StopThrusting();
        }


    }

    void StartThrusting()
    {
        isThrusting = true;
        if (transform.eulerAngles.z > 340f || transform.eulerAngles.z < 20f)
        {
             audioSource.panStereo = 0;
         }
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        PlayThrustAudio();
    }

    void StopThrusting()
    {
        isThrusting = false;
        StopThrustAudio();
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
    }

    void RotateLeft()
    {
        ApplyRotation(-rotationThrust);
        ThrustAudioAdjustStereo(1f);
    }

    void RotateRight()
    {
        ApplyRotation(rotationThrust);
        ThrustAudioAdjustStereo(-1f);
    }

    void ApplyRotation(float rotationThisFrame){
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }

    void PlayThrustAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(thrustAudio);
        }
    }

    void StopThrustAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    void ThrustAudioAdjustStereo(float stereo)
    {
        audioSource.panStereo = stereo * 0.85f;
    }
}
