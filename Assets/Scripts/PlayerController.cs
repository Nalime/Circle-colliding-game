using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private KeyCode keyUp = KeyCode.W;
    private KeyCode keyLeft = KeyCode.A;
    private KeyCode keyDown = KeyCode.S;
    private KeyCode keyRight = KeyCode.D;

    private Circle circle;

    // Start is called before the first frame update
    void Start()
    {
        circle = GetComponent<Circle>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(keyUp)) direction += Vector2.up;
        if (Input.GetKey(keyLeft)) direction += Vector2.left;
        if (Input.GetKey(keyDown)) direction += Vector2.down;
        if (Input.GetKey(keyRight)) direction += Vector2.right;

        circle.Move(direction.normalized, Time.deltaTime);
    }
}
