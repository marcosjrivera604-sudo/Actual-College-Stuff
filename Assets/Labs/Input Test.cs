using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        GetInput();

    }
    public void GetInput()
    {
        Keyboard kb = Keyboard.current;
        Mouse mouse = Mouse.current;

        if ((kb == null) || (mouse == null))
        {
            Debug.LogWarning("No Keyboard or Mouse detected");
            return; 
        }
        
        
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        { 
            Debug.Log("You pressed the Spacebar");
        }
        
        if (mouse.leftButton.wasPressedThisFrame)
        { 
            Debug.Log("You pressed the Left Click buton"); 
        }
        
        

    }
}
