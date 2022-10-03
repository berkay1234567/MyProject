
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    AudioSource audioSource;
    bool hasCollided;
    private void Awake()
    {
        hasCollided = false;
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "RocketShip")
        {
            SuccessfulLanding();
        }
    }

    void SuccessfulLanding()
    {
        if (!hasCollided) { audioSource.Play(); }
        hasCollided = true;
    }
}
