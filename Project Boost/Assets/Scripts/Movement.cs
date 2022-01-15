
using UnityEngine;


public class Movement : MonoBehaviour
{
    Rigidbody rigidBody;
    [SerializeField]
    float mainThrust = 1000f;
    [SerializeField]
    float directionalThrust= 50f;
    // Start is called before the first frame update
    void Start()
    {
       rigidBody = GetComponent<Rigidbody>();
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
        }
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
        transform.Rotate(Vector3.back * rotationThisFrame * Time.deltaTime);
    }
}
