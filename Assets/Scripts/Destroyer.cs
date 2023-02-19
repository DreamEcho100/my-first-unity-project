using System.Diagnostics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private readonly String ENEMY_TAG = "Enemy";
    private readonly String PLAYER_TAG = "Player";

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="collision">The collision Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (
            collision.CompareTag(ENEMY_TAG) ||
            collision.CompareTag(PLAYER_TAG)
        ) Destroy(collision.gameObject);
    }
}
