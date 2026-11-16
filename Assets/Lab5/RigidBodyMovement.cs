using NUnit.Framework.Internal;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UIElements;

public class RigidBodyMovement : MonoBehaviour
{
    public float movespeed = 10;
    public float rotationrate = 180;
    public int playerInputNumber = 0;

    InputData input;

    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        input = InputPoller.reference.GetInput(playerInputNumber);

        MovePlayer(input.leftStick.y);

        RotatePlayer(input.leftStick.x);
    }
        



       
    void MovePlayer(float value)
    {
        gameObject.GetComponent<Rigidbody>().linearVelocity = value * movespeed * gameObject.transform.forward;
    }

    void RotatePlayer(float value)
    {
        gameObject.transform.Rotate(rotationrate * Time.deltaTime * value * Vector3.up);
    }







}
