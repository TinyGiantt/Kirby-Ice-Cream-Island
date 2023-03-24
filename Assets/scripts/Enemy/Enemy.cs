using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f; // Speed at which the enemy moves
    public float health = 50f; // Starting health of the enemy
    public int damage = 10; // Damage the enemy deals to the player on collision

    private Transform player; // Reference to the player's transform
    private Rigidbody2D rb; // Reference to the enemy's rigidbody2D component

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Kirby player").transform; // Find the player's transform
        rb = GetComponent<Rigidbody2D>(); // Get the enemy's rigidbody2D component
    }

    void Update()
    {
        // Move the enemy towards the player's position
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // If the enemy collides with the player, deal damage to the player and destroy the enemy
        if (collision.gameObject.CompareTag("Kirby player"))
        {
            Enemy player = collision.gameObject.GetComponent<Enemy>();
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float amount)
    {
        // Reduce the enemy's health by the specified amount
        health -= amount;

        // If the enemy's health drops below zero, destroy the enemy
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}