using Unity.VisualScripting;
using UnityEngine;

public class MoveableObstacleScript : MonoBehaviour
{
    bool move;

    public void CanItMove(Vector3 direction)
    {
        PerformRayCast(gameObject.transform.position, direction);
        if (move == true)
        {
            gameObject.transform.position += direction;
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
            if (moveable)
            {
                move = false;
            }
            if (nonMoveable)
            {
                move = false;
            }
            else
            {
                move = true;
            }
        }  
    }
}
