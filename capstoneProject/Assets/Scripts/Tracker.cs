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
			Mathf.Clamp(trackedObject.position.x, -5.5f, 5.5f),
			Mathf.Clamp(trackedObject.position.y, -4f, 4f),
			transform.position.z);
    }
}
