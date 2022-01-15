
using UnityEngine;


public class Movement : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource sound;
    [SerializeField]
    float mainThrust = 1000f;
    [SerializeField]
    float directionalThrust= 50f;
    // Start is called before the first frame update
    void Start()
    {
       rigidBody = GetComponent<Rigidbody>();
       sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up*mainThrust*Time.deltaTime);
            if(!sound.isPlaying)
            {
            sound.Play();
            }
            
        }
        else
        sound.Stop();
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            Rotate(-directionalThrust);
        }

        else if(Input.GetKey(KeyCode.D))
        {
            Rotate(directionalThrust);
        }
    }

    private void Rotate(float rotationThisFrame)
    {
        rigidBody.freezeRotation = true;
        transform.Rotate(Vector3.back * rotationThisFrame * Time.deltaTime);
        rigidBody.freezeRotation = false;
    }
}
