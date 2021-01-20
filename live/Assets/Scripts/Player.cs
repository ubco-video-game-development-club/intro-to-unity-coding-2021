using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    public float groundedDist;
    public LayerMask groundedMask;

    private Rigidbody2D rb2D;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(inputX * moveSpeed, rb2D.velocity.y);

        RaycastHit2D hitBelow = Physics2D.Raycast(transform.position, Vector2.down, groundedDist, groundedMask);
        if (hitBelow)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb2D.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            }

            if (hitBelow.transform.TryGetComponent<Enemy>(out Enemy enemy))
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, -rb2D.velocity.y);
                enemy.Stomp();
            }
        }
    }
}
