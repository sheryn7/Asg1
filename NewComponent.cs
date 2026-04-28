using UnityEngine;

public class NewComponent : MonoBehaviour
{
    // // Task 1: Move object along Z-axis
    // Vector3 valueToMove = new Vector3(0, 0, 0.01f); // moving Z-axis

    // // Task 2: Object reaches certain amt then will move opp direction
    // // Update is called once per frame
    // void Update()
    // {
    //     transform.localPosition += valueToMove;

    //     // if too far forward
    //     if (transform.localPosition.z > 5)
    //     {
    //         valueToMove.z = -0.01f;     // moves object backwards
    //     }

    //     // if too far backward
    //     if (transform.localPosition.z < -5)
    //     {
    //         valueToMove.z = 0.01f;      // moves object forward
    //     }

        // Task 3: Rotation
        Vector3 rotationValue = new Vector3(0, 1f, 0);

        void Update()
    {
        transform.localEulerAngles += rotationValue;

        // if rotate too far to the right side,
        if (transform.localEulerAngles.y > 180)
        {
            rotationValue.y = -1f;
        }

        // if rotate too far to the left side,
        if (transform.localEulerAngles.y < 10)
        {
            rotationValue.y = 1f;
        }

        print(transform.localEulerAngles.y);
    }
}

//         print(transform.localPosition.x);
//         print(transform.localPosition.y);
//         print(transform.localPosition.z);
//     }
// }