using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float powerUpDuration = 10f; // Duration of the power up in seconds
    public float powerUpAmount = 2f; // Amount to increase player's power by

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Kirby player"))
        {
            // Apply power up to player
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ApplyPowerUp(powerUpDuration, powerUpAmount);
            }

            // Destroy power up object
            Destroy(gameObject);
        }
    }
}
