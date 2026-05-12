using UnityEngine;
using UnityEngine.InputSystem;

public class NewObject : MonoBehaviour
{
    public int collCount = 0;
    public int currentScore = 0;

    GameObject currentCollectible;

    void OnCollisionEnter(Collision collision)
    {
        print("Player collided with " + collision.gameObject.name);
        if(collision.gameObject.tag.Contains("Collectible"))
        {
            currentCollectible = collision.gameObject;
        }
    }

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            OnInteract();
        }
    }

    void OnInteract()
    {
        print("Player wants to interact");

        if(currentCollectible != null)
        {
            CollectibleScore scoreScript = currentCollectible.GetComponent<CollectibleScore>();

            currentScore += scoreScript.scoreValue;
            collCount++;

            print("Collected " + collCount);
            print("Current Score: " + currentScore);

            Destroy(currentCollectible);
            currentCollectible = null;
        }
    }
}
