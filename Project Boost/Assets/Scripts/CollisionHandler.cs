using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]
    float levelChangeDelay = 5f;
private void OnCollisionEnter(Collision other)
{
        switch(other.gameObject.tag)
        
        {
            case "Friendly":
                Debug.Log("This is Friendly");
            break;
            case "Finish":
                Debug.Log("This is end");
                Invoke("NextLevel", levelChangeDelay);
            break;
            case "Fuel":
                Debug.Log("This is Fuel");
            break;
            default:
                StartCrashSequence();
                break;
        }
}

    void StartCrashSequence()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<Movement>().enabled = false;
        Debug.Log("You blew Up");
        Invoke("ReloadLevel", 5f);
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
