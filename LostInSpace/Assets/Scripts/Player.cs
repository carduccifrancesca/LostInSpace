using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    Rigidbody2D body;
    private float movement = 0f;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
    }

     void FixedUpdate()
     {
        Vector2 newVelocity = new Vector2(movement * speed, body.velocity.y);
        body.velocity = newVelocity;
     }
}
