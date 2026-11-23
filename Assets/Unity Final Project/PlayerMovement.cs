using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector3 position;
    bool canmove = true;
    Keyboard kb = Keyboard.current;
    public GameObject raySpawn;

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
            PerformRaycast(raySpawn.transform.position, raySpawn.transform.forward * 10);
        }
        if (kb.sKey.wasPressedThisFrame)
        {
            position += gameObject.transform.forward * -10;
            PerformRaycast(raySpawn.transform.position, raySpawn.transform.forward * -10);
        }
        if (kb.dKey.wasPressedThisFrame)
        {
            position += gameObject.transform.right * 10;
            PerformRaycast(raySpawn.transform.position, raySpawn.transform.right * 10);
        }
        if (kb.aKey.wasPressedThisFrame)
        {
            position += gameObject.transform.right * -10;
            PerformRaycast(raySpawn.transform.position, raySpawn.transform.right * -10);
        }
        if(canmove == true)
        {
            gameObject.transform.position = position;
        }
        

    }
    public void PerformRaycast(Vector3 start, Vector3 direction)
    {
        RaycastHit hit;
        bool hashit = Physics.Raycast(start, direction, out hit, 10);
        if (hashit)
        {
            MoveableObstacleScript moveable = hit.collider.gameObject.GetComponentInParent<MoveableObstacleScript>();
            StaticObjectScript nonMoveable = hit.collider.gameObject.GetComponentInParent <StaticObjectScript>();
            if(moveable)
            {
                canmove = false;
                moveable.GetComponent<MoveableObstacleScript>().CanItMove(direction);
            }
            if(nonMoveable)
            {
                canmove = false;
            }
            else
            {
                canmove = true;
            }
        }
       
    }
}
