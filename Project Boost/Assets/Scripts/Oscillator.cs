
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 2f;
    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        if(period <= Mathf.Epsilon)
        {
            return;
           // period =+ 0.1f;
        }
        float cycles = Time.time/ period; //continually growing over time
        const float tau = Mathf.PI *2; //constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles*tau); // goes from -1 to 1
        movementFactor = (rawSinWave + 1f)/ 2f; // reclaculated to go from -1 to 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
