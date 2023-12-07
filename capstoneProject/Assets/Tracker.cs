using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    public Transform trackedObject;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(
<<<<<<< Updated upstream:capstoneProject/Assets/Tracker.cs
			Mathf.Clamp(trackedObject.position.x, -4f, 4f),
			Mathf.Clamp(trackedObject.position.y, -1.5f, 1.5f),
=======
			Mathf.Clamp(trackedObject.position.x, -5f, 5.5f),
			Mathf.Clamp(trackedObject.position.y, -4f, 4f),
>>>>>>> Stashed changes:capstoneProject/Assets/Scripts/Tracker.cs
			transform.position.z);
    }
}
