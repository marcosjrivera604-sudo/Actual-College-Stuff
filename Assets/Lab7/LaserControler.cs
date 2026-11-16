using UnityEngine;

public class LaserControler : MonoBehaviour
{
    public GameObject LaserModel;
    public float LaserShowTime = 2f;
    float LaserShowCounter = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LaserModel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (LaserShowCounter > 0)
        {
            LaserShowCounter -= Time.deltaTime;
            if (LaserShowCounter <= 0)
            {
                LaserModel.SetActive(false);
            }
        }
    }

    public void FireLaser(float distance)
    {
        LaserModel.SetActive(true);
        LaserShowCounter = LaserShowTime;

        Vector3 newScale = Vector3.one;
        newScale.z = distance;
        gameObject.transform.localScale = newScale;
    }
}
