using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    private new Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddTorque(50);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.back * 10;
    }
}
