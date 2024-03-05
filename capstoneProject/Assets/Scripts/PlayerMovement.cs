using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private float xdir, ydir, speed;

    //animator testing
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 5f;

        //animator testing, getting component
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        xdir = Input.GetAxisRaw("Horizontal") * speed;
        ydir = Input.GetAxisRaw("Vertical") * speed;

        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, -10.5f, 10.5f),
            Mathf.Clamp(transform.position.y, -5f, 5f)
        );

        //animator testing, updating animator on player movement
        animator.SetFloat("Horizontal", xdir);
        animator.SetFloat("Vertical", ydir);
    }

    public void FixedUpdate()
    {
        rb.velocity = new Vector2(xdir, ydir);
    }

    public Vector2 getPos()
    {
        return rb.velocity;
    }
}
