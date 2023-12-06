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
            Mathf.Clamp(transform.position.x, -8f, 13f),
            Mathf.Clamp(transform.position.y, -9f, 9f)
        );
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(xdir, ydir);
    }
}
