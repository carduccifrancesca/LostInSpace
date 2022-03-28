using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpSpeed = 10f;
    private Rigidbody2D player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.y <= 0f)
        {   
            player = collision.collider.attachedRigidbody;
            if (player != null && player.tag == "Player")
            {
                Vector2 vector = new Vector2(player.velocity.x, jumpSpeed);
                player.velocity = vector;
            }
        }
    }
}
