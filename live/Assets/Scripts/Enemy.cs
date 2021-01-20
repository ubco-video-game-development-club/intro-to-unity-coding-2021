using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public UnityEvent deathEvent;

    private Transform player;
    private Rigidbody2D rb2D;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        float dirX = Mathf.Sign((player.position - transform.position).x);
        rb2D.velocity = new Vector2(dirX * moveSpeed, rb2D.velocity.y);
    }

    public void Stomp()
    {
        deathEvent.Invoke();
        Destroy(gameObject);
    }
}
