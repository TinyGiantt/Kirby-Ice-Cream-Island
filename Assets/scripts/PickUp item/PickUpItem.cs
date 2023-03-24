using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public int pointsToAdd; // The number of points to add when the item is picked up

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Kirby player")) // If the item coll
}