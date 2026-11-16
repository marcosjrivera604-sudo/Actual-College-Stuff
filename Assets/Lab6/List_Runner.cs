using UnityEngine;
using System.Collections.Generic;
public class List_Runner : MonoBehaviour
{
    GameObject currentTarget;
    public float movementSpeed = 5;
    public float withingRange = .75f;
    Vector3 moveDirection;
    public bool hasDynamicDirection = false;
    public List<GameObject> pathList;
    int pathListIndex;
    public int pathListAmount; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pathListIndex = 0;
        currentTarget = pathList[pathListIndex];
        UpdateMoveDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasDynamicDirection)
        {
            UpdateMoveDirection();
        }

        //MoveRunner TO DO

        Vector3 location = gameObject.transform.position;
        location += moveDirection * movementSpeed * Time.deltaTime;
        gameObject.transform.position = location;


        if (IsClosetoTarget())
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
        if (GetDistanceTo(currentTarget) <= withingRange)
        {
            return true;
        }
        else
            return false;
    }

    void NextTarget()
    {
        ++pathListIndex;
        if(pathListIndex > pathListAmount-1)
        {
            pathListIndex = 0;
        }
        currentTarget = pathList[pathListIndex];
    }

    public void UpdateMoveDirection()
    {
        Vector3 directionVector = currentTarget.transform.position - gameObject.transform.position;
        moveDirection = directionVector.normalized;

        gameObject.transform.forward = moveDirection;

    }
}