using NUnit.Framework.Internal;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UIElements;

public class SmoothMovement : MonoBehaviour
{
    public float movespeed = 10;
    public float  rotationrate = 180;



    bool forward;
    bool clockwise;
    bool backwards;
    bool counterclockwise;

 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();

        if (forward)
        {
            MovePlayer(1);
        }

        if (backwards)
        {
            MovePlayer(-1);
        }

        if (counterclockwise)
        {
            RotatePlayer(1);
        }
        if (clockwise)
        {
            RotatePlayer(-1);
        }
    }
    void GetInput()
    {
        Keyboard kb = Keyboard.current;
        Mouse mouse = Mouse.current;


        forward = kb.wKey.isPressed;

        clockwise = kb.aKey.isPressed;

        backwards = kb.sKey.isPressed;

        counterclockwise = kb.dKey.isPressed;



    }

    void MovePlayer(float value)
    {
        Vector3 location = gameObject.transform.position;
        location += gameObject.transform.forward * movespeed * value * Time.deltaTime;
        gameObject.transform.position = location;
    }

    void RotatePlayer(float value)
    {
        gameObject.transform.Rotate(rotationrate * Time.deltaTime * value * Vector3.up);
    }







}
