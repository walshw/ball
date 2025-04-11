using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public float jumpStrength = 1f;
    public float rayLength = 0.5f;
    private Rigidbody2D rb;
    private Collider2D cl;
    private bool grounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cl = GetComponent<Collider2D>();
    }

    void Update()
    {
        GroundCheck();
        
        if (Input.GetKeyDown(KeyCode.Space) & grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
        }

        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
    }

    void GroundCheck() {
        // Adding 0.1f to make ray start outside collider
        Vector2 bottom = new Vector2(transform.position.x, transform.position.y - cl.bounds.extents.y - 0.1f);
        if (Physics2D.Raycast(bottom, Vector2.down, rayLength))
        {
            grounded = true;
        } else {
            grounded = false;
        }
    }
}
