using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 cameraOffset;

    public Transform following;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (following)
        {
            transform.position = following.position + cameraOffset;
        }
    }
}
