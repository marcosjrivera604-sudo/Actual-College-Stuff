
using Unity.Burst.CompilerServices;
using UnityEngine;


public class BobScript : MonoBehaviour
{
    public float height = 10;
    public float speed = 3;
    Vector3 Slocation;
    float ceiling;
    float floor;
    float direction=1;

    void Start()
    {
        Slocation = gameObject.transform.position;
        ceiling = Slocation.y + height;
        floor = Slocation.y;
    }


    void Update()
    {   
        Vector3 location = gameObject.transform.position;

        location.y += speed * direction * Time.deltaTime;

        if (location.y >= ceiling)
        {
            direction = -1;
            location.y = ceiling;
        }

        if (location.y <= floor)
        {
            direction = 1;
            location.y = floor;
        }
        gameObject.transform.position = location;
    
    
    }
}