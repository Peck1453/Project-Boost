using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioClip thrusters;
    AudioSource sound;
    ParticleSystem particles;

    [SerializeField]
    AudioClip thrusterSound;
    [SerializeField]
    float mainThrust = 1000f;
    [SerializeField]
    float directionalThrust= 50f;

    [SerializeField]    ParticleSystem leftThrusterParticles;
    [SerializeField]    ParticleSystem rightThrusterParticles;
    [SerializeField]    ParticleSystem mainThrusterParticles;



    void Start()
    {
       rigidBody = GetComponent<Rigidbody>();
       sound = GetComponent<AudioSource>();
       particles = GetComponent<ParticleSystem>();
    }

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
            sound.PlayOneShot(thrusterSound);
            }
            if(!mainThrusterParticles.isPlaying)
            {
            mainThrusterParticles.Play();
            }
        }
        else
        {
        sound.Stop();
        mainThrusterParticles.Stop();
        }
    }

    private void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            Rotate(-directionalThrust);
            if(!leftThrusterParticles.isPlaying)
            {
            leftThrusterParticles.Play();
            }
        }

        else if(Input.GetKey(KeyCode.D))
        {
            Rotate(directionalThrust);
            if(!rightThrusterParticles.isPlaying)
            {
            rightThrusterParticles.Play();
            }
        }
        else
        {
       rightThrusterParticles.Stop();
       leftThrusterParticles.Stop();
        }
    }

    private void Rotate(float rotationThisFrame)
    {
        rigidBody.freezeRotation = true;
        transform.Rotate(Vector3.back * rotationThisFrame * Time.deltaTime);
        rigidBody.freezeRotation = false;
    }
}
