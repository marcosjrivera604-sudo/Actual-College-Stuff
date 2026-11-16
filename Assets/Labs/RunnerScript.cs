using UnityEngine;

public class RunnerScript : MonoBehaviour

{
    public GameObject targetA;
    public GameObject targetB;
    GameObject currentTarget;
    bool isMovingToTargetA;
    public float movementSpeed = 5;
    public float withingRange = .75f;
    Vector3 moveDirection;
    public bool hasDynamicDirection = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isMovingToTargetA = true;
        currentTarget = targetA;
        UpdateMoveDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if(hasDynamicDirection)
        {
            UpdateMoveDirection();
        }

        //MoveRunner TO DO

        Vector3 location = gameObject.transform.position;
        location += moveDirection * movementSpeed * Time.deltaTime;
        gameObject.transform.position = location;


        if ( IsClosetoTarget() )
        {
            // next target 
            // update move direction 
            NextTarget();
            UpdateMoveDirection();

        }

        
    }

    public float GetDistanceTo(GameObject other)
    {
        Vector3 distance = other.transform.position - gameObject.transform.position;
        return distance.magnitude;
    }

    public bool IsClosetoTarget()
    {
        if ( GetDistanceTo(currentTarget) <= withingRange )
        {
            return true; 
        }
        return false; 
    }

    void NextTarget()
    {
        if (isMovingToTargetA)
        {
            isMovingToTargetA = false;
            currentTarget = targetB;
        }
        else
        {
            isMovingToTargetA = true;
            currentTarget = targetA;
        }
    }

    public void UpdateMoveDirection()
    {
        Vector3 directionVector = currentTarget.transform.position - gameObject.transform.position;
        moveDirection = directionVector.normalized;

        gameObject.transform.forward = moveDirection;

    }
}
