using UnityEngine;

public class PinkoSlot : MonoBehaviour
{
    public int score;
    public GameObject totalPoints;
    void OnTriggerEnter(Collider other)
    {
        PlinkoDisk plinko = other.gameObject.GetComponentInParent<PlinkoDisk>();
        
        Destroy(plinko.gameObject,2f);
        if (plinko)
        {
            totalPoints.GetComponent<PlinkoPoints>().UpdatePoints(score);
        }
    }
    // Update is called once per frame
    
}

