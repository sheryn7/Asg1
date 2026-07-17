using UnityEngine;
using UnityEngine.AI;

public class ChasingAI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;
    [SerializeField] private NavMeshAgent agent;

    [Header("Vision Settings")]
    [SerializeField] private float viewDistance = 10f;
    [Range(0f, 360f)]
    [SerializeField] private float viewAngle = 90f;
    [SerializeField] private LayerMask obstacleLayer;

    [Header("Return Settings")]
    [SerializeField] private float homeStoppingDistance = 0.2f;

    private Vector3 originalPosition;
    private bool isChasing;

    private void Awake()
    {
        // Automatically find the NavMeshAgent if it was not assigned.
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
    }

    private void Start()
    {
        // Save the enemy's starting position for Task 4.
        originalPosition = transform.position;
    }

    private void Update()
    {
        if (player == null)
        {
            Debug.LogError("Player has not been assigned!");
            return;
        }

        bool canSeePlayer = CanSeePlayer();

        Debug.Log("Can see player: " + canSeePlayer);

        if (canSeePlayer)
        {
            ChasePlayer();
        }
        else if (isChasing)
        {
            ReturnHome();
        }
    }

    private bool CanSeePlayer()
    {
        if (player == null)
        {
            return false;
        }

        Vector3 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        // Player is outside the enemy's vision range.
        if (distanceToPlayer > viewDistance)
        {
            return false;
        }

        Vector3 directionNormalised = directionToPlayer.normalized;

        // Check whether the player is inside the enemy's vision angle.
        float angleToPlayer = Vector3.Angle(
            transform.forward,
            directionNormalised
        );

        if (angleToPlayer > viewAngle / 2f)
        {
            return false;
        }

        // Check whether a wall or obstacle blocks the enemy's view.
        Vector3 eyePosition = transform.position + Vector3.up;

        if (Physics.Raycast(
                eyePosition,
                directionNormalised,
                distanceToPlayer,
                obstacleLayer))
        {
            return false;
        }

        return true;
    }

    private void ChasePlayer()
    {
        isChasing = true;
        agent.isStopped = false;

        // Constantly update the destination as the player moves.
        agent.SetDestination(player.position);
    }

    private void ReturnHome()
    {
        agent.isStopped = false;
        agent.SetDestination(originalPosition);

        // Wait until Unity has finished calculating the path.
        if (agent.pathPending)
        {
            return;
        }

        // Stop once the enemy reaches its original position.
        if (agent.remainingDistance <= homeStoppingDistance)
        {
            agent.ResetPath();
            agent.isStopped = true;
            isChasing = false;

            // Face the enemy's original forward direction if needed.
            transform.position = originalPosition;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw the enemy's vision range.
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewDistance);

        // Draw the two sides of the vision cone.
        Vector3 leftBoundary =
            DirectionFromAngle(-viewAngle / 2f);

        Vector3 rightBoundary =
            DirectionFromAngle(viewAngle / 2f);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(
            transform.position,
            transform.position + leftBoundary * viewDistance
        );

        Gizmos.DrawLine(
            transform.position,
            transform.position + rightBoundary * viewDistance
        );

        // Draw a line toward the player when detected.
        if (Application.isPlaying && CanSeePlayer())
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, player.position);
        }
    }

    private Vector3 DirectionFromAngle(float angle)
    {
        float finalAngle = transform.eulerAngles.y + angle;

        return new Vector3(
            Mathf.Sin(finalAngle * Mathf.Deg2Rad),
            0f,
            Mathf.Cos(finalAngle * Mathf.Deg2Rad)
        );
    }
}