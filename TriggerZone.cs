using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (NewObject.collectiblesLeft == 0)
            {
                print("You collected all collectibles!");
            }
            else
            {
                print("Collect all objects first");
            }
        }
    }
}
