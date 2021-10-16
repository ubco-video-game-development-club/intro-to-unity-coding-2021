using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float jumpForce = 10.0f;
    public LayerMask groundMask;
    public Transform feet;
    private Rigidbody2D rig;
    private bool canJump = false;

    void Awake() 
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump") && canJump) rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void FixedUpdate() 
    {
        // Movement
        float input = Input.GetAxis("Horizontal");

        Vector2 v = rig.velocity;
        rig.velocity = new Vector2(input * moveSpeed, v.y);

        // Grounded check
        Collider2D col = Physics2D.OverlapCircle(feet.position, 0.2f, groundMask);
        canJump = col != null;
    }
}
