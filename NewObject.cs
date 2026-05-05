using UnityEngine;

public class NewObject : MonoBehaviour
{
    public static int collectiblesLeft = 0;

    void Start()
    {
        collectiblesLeft++;     // count object when scene starts
    }

    void OnCollisionEnter(Collision collision)
    {
        print("Collision detected with " + collision.gameObject.name);

        // Task 1: Player touch object = object disappears
        if(collision.gameObject.name == "Player")
        {
            collectiblesLeft--;     // reduce count when collected
            Destroy(gameObject);
        }
    }

    // void OnCollisionStay(Collision collision)
    // {
    //     print("Colliding with " + collision.gameObject.name);
    // }
}
