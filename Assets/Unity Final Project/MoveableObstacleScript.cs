using Unity.VisualScripting;
using UnityEngine;

public class MoveableObstacleScript : MonoBehaviour
{
    Vector3 startPosition;
    bool move =true;
    void Start()
    {
        startPosition = gameObject.transform.position;
    }
    public void CanItMove(Vector3 moveDirection)
    {
        PerformRayCast(gameObject.transform.position, moveDirection);
        if (move == true)
        {
            gameObject.transform.position += moveDirection;

        }
        else
        {
            move = true;
        }
    }
    void PerformRayCast(Vector3 start, Vector3 direction)
    {
        RaycastHit hit;
        bool hashit = Physics.Raycast(start, direction, out hit, 10);
        if (hashit)
        {
            MoveableObstacleScript moveable = hit.collider.gameObject.GetComponentInParent<MoveableObstacleScript>();
            StaticObjectScript nonMoveable = hit.collider.gameObject.GetComponentInParent<StaticObjectScript>();
            if (moveable||nonMoveable)
            {
                move = false;
            }
            else
            {
                move = true;
            }
        }  
    }
    public void ResetPosition()
    {
        gameObject.transform.position = startPosition;
        Debug.Log("Position Reset");
    }
}
