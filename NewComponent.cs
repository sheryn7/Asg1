using UnityEngine;

public class NewComponent : MonoBehaviour
{

    Vector3 valueToMove = new Vector3(0, 0, 0.01f); // moving Z-axis

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += valueToMove;

        // if too far forward
        if (transform.localPosition.z > 5)
        {
            valueToMove.z = -0.01f;     // moves object backwards
        }

        // if too far backward
        if (transform.localPosition.z < -5)
        {
            valueToMove.z = 0.01f;      // moves object forward
        }

        print(transform.localPosition.x);
        print(transform.localPosition.y);
        print(transform.localPosition.z);
    }
}