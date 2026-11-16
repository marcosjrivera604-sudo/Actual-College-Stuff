using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class SoccerBall : MonoBehaviour
{
    Vector3 startingLocation;
    quaternion startingRotation;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         startingLocation = gameObject.transform.position;
         startingRotation = gameObject.transform.rotation;
         rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetObject()
    {
        gameObject.transform.position = startingLocation;
        gameObject.transform.rotation = startingRotation;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}   

