using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private float xdir, ydir, speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 5f;
    }
    
    void Update()
    {
        xdir = Input.GetAxisRaw("Horizontal") * speed;
        ydir = Input.GetAxisRaw("Vertical") * speed;

        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, -4f, 12f),
            Mathf.Clamp(transform.position.y, -6f, 6f)
        );
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(xdir, ydir);
    }
}
