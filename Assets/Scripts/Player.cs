using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    public float groundedDist;
    public LayerMask groundedLayer;

    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb2D.velocity.y);
        rb2D.velocity = movement;
        
        bool isGrounded = CheckBelow();
        if (Input.GetButtonDown("Jump") && CheckBelow())
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }
    }

    private bool CheckBelow()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, groundedLayer);

        if (hit && hit.transform.TryGetComponent<Enemy>(out Enemy enemy))
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, -rb2D.velocity.y);
            enemy.Die();
        }

        return hit;
    }
}
