using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public UnityEvent deathEvent;

    private Rigidbody2D rb2D;
    private Transform player;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float xDist = (player.position - transform.position).x;
        float xDir = Mathf.Sign(xDist);
        rb2D.velocity = new Vector2(xDir * moveSpeed, rb2D.velocity.y);
    }

    public void Die()
    {
        deathEvent.Invoke();
        Destroy(gameObject);
    }
}
