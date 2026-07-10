using UnityEngine;

public class BallKick : MonoBehaviour
{
    [Header("Kick Settings")]
    [SerializeField] private float kickForce = 8f;
    [SerializeField] private float upwardForce = 2f;

    private Rigidbody ballRigidbody;
    private Transform playerTransform;
    private bool playerNearby = false;

    private void Awake()
    {
        ballRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            KickBall();
        }
    }

    private void KickBall()
    {
        if (ballRigidbody == null || playerTransform == null)
        {
            return;
        }

        Vector3 kickDirection =
            (transform.position - playerTransform.position).normalized;

        Vector3 finalForce =
            (kickDirection * kickForce) + (Vector3.up * upwardForce);

        ballRigidbody.AddForce(finalForce, ForceMode.Impulse);

        Debug.Log("Ball kicked!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            playerTransform = other.transform;

            Debug.Log("Press E to kick the Ball.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            playerTransform = null;
        }
    }
}
