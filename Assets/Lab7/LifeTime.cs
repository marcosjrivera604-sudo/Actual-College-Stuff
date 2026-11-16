using UnityEngine;

public class LifeTime : MonoBehaviour
{
    public float lifetime = 3.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject,lifetime);
    }
}
