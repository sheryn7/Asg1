using UnityEngine;

public class GoalArea : MonoBehaviour
{
    [SerializeField] private int scoreValue = 1;

    private int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            score += scoreValue;

            Debug.Log("GOAL! Score: " + score);
        }
    }
}