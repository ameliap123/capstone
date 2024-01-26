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
			Mathf.Clamp(trackedObject.position.x, -0f, 0f),
			Mathf.Clamp(trackedObject.position.y, -0f, 0f),
			transform.position.z);
    }
}
