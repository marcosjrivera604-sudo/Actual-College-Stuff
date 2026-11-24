using UnityEngine;

public class ResetScript : MonoBehaviour
{
    public MoveableObstacleScript[] moveableObstaclesList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveableObstaclesList = GameObject.FindObjectsByType<MoveableObstacleScript>(FindObjectsSortMode.None);
    }
    public void ResetEverything()
    {
        foreach (MoveableObstacleScript rp in moveableObstaclesList)
        {
            rp.ResetPosition();
        }
        

       

        
    }
}
