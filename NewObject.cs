using UnityEngine;

public class NewObject : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        print("Collision detected with " + collision.gameObject.name);

        // Task 1: Player touch object = object disappears
        if(collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
    }

    // void OnCollisionStay(Collision collision)
    // {
    //     print("Colliding with " + collision.gameObject.name);
    // }
}
