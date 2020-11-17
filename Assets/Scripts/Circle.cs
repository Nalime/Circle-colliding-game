using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private new Collider2D collider;
    public SpriteRenderer sprite;

    public float moveSpeed = 10.0f;
    public float moveAcceleration = 50.0f;

    public int onGround = 0;

    public bool isFalling = false;
    public float fallTime = 0.0f;
    public float fallEnd = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            if (fallTime >= fallEnd)
            {
                GameManager.instance.KillCircle(this);
            }
            else
            {
                transform.localScale =
                    Vector3.one * (1.0f - fallTime / fallEnd);
                fallTime += Time.deltaTime;
            }
        }
    }

    public void Move(Vector2 direction, float deltaTime)
    {
        if (direction == Vector2.zero) return;

        float oldMagnitude = rigidbody.velocity.magnitude;
        Vector2 deltaVelocity = moveAcceleration * direction * deltaTime;
        rigidbody.velocity += deltaVelocity;

        if (rigidbody.velocity.magnitude > moveSpeed)
        {
            rigidbody.velocity *=
                Mathf.Max(10.0f, oldMagnitude)
                / rigidbody.velocity.magnitude;
        }
    }

    public void Fall()
    {
        isFalling = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        switch (other.gameObject.tag)
        {
            case "Ground":
                onGround++;
                break;
            case "Void":
                Fall();
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        switch (other.gameObject.tag)
        {
            case "Ground":
                onGround--;
                if (onGround == 0) Fall();
                break;
        }
    }
}
