using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public LayerMask jumpMask;
    public UnityEvent onDie;
    private GameObject player;
    private Rigidbody2D rig;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rig = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Movement
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rig.velocity = new Vector2(direction.x * moveSpeed, rig.velocity.y);

        // Getting Curb Stomped
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.7f, jumpMask);
        if(hit)
        {
            // Die!
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        onDie.Invoke();
    }
}
