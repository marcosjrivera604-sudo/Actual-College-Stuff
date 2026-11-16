using UnityEngine;

public class PlinkoPoints : MonoBehaviour
{
    public int totalScore = 0;

    public void UpdatePoints(int score)
    {
        totalScore += score;
        Debug.Log("Scored " + score + " for a toal of " + totalScore);
    }





}