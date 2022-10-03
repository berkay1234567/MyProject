using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay;
    [SerializeField] AudioClip crashAudio;
    [SerializeField] AudioClip successAudio;
    AudioSource audioSource;
    Movement movement;

    public bool isTransitioning;
    
    private void Awake()
    {
        movement = this.gameObject.GetComponent<Movement>();
        audioSource = this.gameObject.GetComponent<AudioSource>();  
    }
    void OnCollisionEnter(Collision other)
    {
        if (!isTransitioning)
        {
            switch (other.gameObject.tag)
            {
                case "Friendly":

                    break;
                case "FinishLine":
                    StartSuccessSequence();
                    break;
                default:
                    StartCrashSequence();
                    break;
            }
        }
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crashAudio);
        movement.enabled = false;
        
        Invoke("ReloadLevel", levelLoadDelay);
        
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex+1);
    }
}
