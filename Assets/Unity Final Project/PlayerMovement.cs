using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector3 position;
    Vector3 startPosition;
    bool canmove = true;
    Keyboard kb = Keyboard.current;
    public ResetScript ResetButton;
    void Start()
    {
        startPosition = gameObject.transform.position;
    }
    void Update()
    {
        GridMovement();
    }



    void GridMovement()
    {


        position = gameObject.transform.position;

        if (kb.wKey.wasPressedThisFrame)
        {
            position += gameObject.transform.forward * 10;
            PerformRaycast(gameObject.transform.position, gameObject.transform.forward * 10);      
        }
        if (kb.sKey.wasPressedThisFrame)
        {
            position += gameObject.transform.forward * -10;
            PerformRaycast(gameObject.transform.position, gameObject.transform.forward * -10);      
        }
        if (kb.dKey.wasPressedThisFrame)
        {
            position += gameObject.transform.right * 10;
            PerformRaycast(gameObject.transform.position, gameObject.transform.right * 10);         
        }
        if (kb.aKey.wasPressedThisFrame)
        {
            position += gameObject.transform.right * -10;
            PerformRaycast(gameObject.transform.position, gameObject.transform.right * -10);
        }
        if (kb.rKey.wasPressedThisFrame)
        {
            ResetButton.ResetEverything();
            Restart();
            return;
        }
        if(canmove == true)
        {
            gameObject.transform.position = position;
            
        }
        else
        {
            position = gameObject.transform.position;
            canmove = true;
        }
        

    }
    public void PerformRaycast(Vector3 start, Vector3 direction)
    {
        RaycastHit hit;
        Debug.DrawRay(start,direction,Color.red,3f);
        bool hashit = Physics.Raycast(start, direction, out hit, 10);
        if (hashit)
        {
            MoveableObstacleScript moveable = hit.collider.gameObject.GetComponentInParent<MoveableObstacleScript>();
            StaticObjectScript nonMoveable = hit.collider.gameObject.GetComponentInParent <StaticObjectScript>();
            
            if(nonMoveable)
            {
                canmove = false;
                return;
                
            }
            if (moveable)
            {
                canmove = false;
                moveable.GetComponent<MoveableObstacleScript>().CanItMove(direction);
            }
            else
            {
               
                canmove = true;
            }
        }
       
    }
    public void Restart()
    {
        gameObject.transform.position = startPosition;
    }
}
