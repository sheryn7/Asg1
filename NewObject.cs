using UnityEngine;
using UnityEngine.InputSystem;

public class NewObject : MonoBehaviour
{
    public int collCount = 0;

    GameObject currentCollectible;

    void OnCollisionEnter(Collision collision)
    {
        print("Player collided with " + collision.gameObject.name);
        if(collision.gameObject.tag.Contains("Collectible"))
        {
            currentCollectible = collision.gameObject;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "GoalArea" && collCount >= 7)
        {
            print("Player entered trigger zone with " + collCount + "collectibles");
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
            Destroy(currentCollectible);
            collCount++;

            print("Collected " + collCount);
        }
    }
}
