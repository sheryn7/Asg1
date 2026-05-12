using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        NewObject playerScript = other.GetComponent<NewObject>();

        if(playerScript != null)
        {
            if(playerScript.collCount >= 2)
            {
                print("You collected all collectibles!");
            }
            else
            {
                print("Collect all collectibles first");
            }
        }
    }
}