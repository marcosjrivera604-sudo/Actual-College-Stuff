using UnityEngine;
using UnityEngine.InputSystem;


public class Grid_Movement : MonoBehaviour

{
    bool north;

    bool south;

    bool east;
    
    bool west;

    public int gridSize= 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GridMovement();

        Vector3 location = gameObject.transform.position;

        if (north)
        {
            location += (Vector3.forward*gridSize);
            gameObject.transform.forward = Vector3.forward;
        }

        if (west)
        {
            location += (Vector3.left*gridSize);
            gameObject.transform.forward = Vector3.left;
        }

        if (south)
        {
            location += (Vector3.back*gridSize);
            gameObject.transform.forward = Vector3.back;
        }

        if (east)
        {
            location += (Vector3.right*gridSize);
            gameObject.transform.forward = Vector3.right;
        }

        gameObject.transform.position = location;


    }
    void GridMovement()
    {
        Keyboard kb = Keyboard.current;
        Mouse mouse = Mouse.current;


        north = kb.iKey.wasPressedThisFrame;
        
        west = kb.jKey.wasPressedThisFrame;
       
        south = kb.kKey.wasPressedThisFrame;
       
        east = kb.lKey.wasPressedThisFrame;
        
    }
}
