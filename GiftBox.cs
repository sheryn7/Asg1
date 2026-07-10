using UnityEngine;

public class GiftBox : MonoBehaviour
{
    [Header("GiftBox Settings")]
    [SerializeField] private int pressesRequired = 3;

    [Header("Ball Settings")]
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform ballSpawnPoint;

    private int currentPresses = 0;
    private bool playerNearby = false;

    private void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            currentPresses++;

            Debug.Log("GiftBox pressed: " + currentPresses + "/" + pressesRequired);

            if (currentPresses >= pressesRequired)
            {
                DestroyGiftBox();
            }
        }
    }

    private void DestroyGiftBox()
    {
        Debug.Log("GiftBox destroyed!");

        if (ballPrefab != null && ballSpawnPoint != null)
        {
            Instantiate(
                ballPrefab,
                ballSpawnPoint.position,
                ballSpawnPoint.rotation
            );
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            Debug.Log("Press E three times to open the GiftBox.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}