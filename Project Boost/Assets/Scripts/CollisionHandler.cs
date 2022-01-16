using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    AudioSource sound;
    ParticleSystem particles;

    [SerializeField]    AudioClip deathExplosion;
    [SerializeField]    AudioClip successNoise;
    [SerializeField]    ParticleSystem deathExplosionParticles;
    [SerializeField]    ParticleSystem successParticles;

    [SerializeField]    float levelChangeDelay = 5f;

    bool isTransitioning = false;
    bool collisionDisabled = false;

    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        RespondToDebugKeys();
    }


      

    private void RespondToDebugKeys()
    {

         if(Input.GetKeyDown(KeyCode.L))
        {
            NextLevel();
        }

        else if(Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;
        }
    }

    void OnCollisionEnter(Collision other)

    {
        if(isTransitioning || collisionDisabled)
        {
            return;
        }
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This is Friendly");
            break;
            case "Finish":
            StartSuccessSequence();
            break;
            case "Fuel":
                Debug.Log("This is Fuel");
            break;
            default:
                StartCrashSequence();
            break;
        }
    }

    private void StartCrashSequence()
    {
        sound.Stop();
        isTransitioning = true;
        sound.PlayOneShot(deathExplosion);
        deathExplosionParticles.Play();
        GetComponent<Movement>().enabled = false;
        Debug.Log("You blew Up");
        Invoke("ReloadLevel", levelChangeDelay);
    }

    private void StartSuccessSequence()  
    {
        sound.Stop();

        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        GetComponent<Movement>().enabled = false;
        sound.PlayOneShot(successNoise);
        successParticles.Play();
        Debug.Log("This is end");
        Invoke("NextLevel", levelChangeDelay);
    }

    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex +1;

        if(nextSceneIndex==SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
}
