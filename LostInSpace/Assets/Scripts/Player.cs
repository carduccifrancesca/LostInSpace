using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private Rigidbody2D body;
    private float horizontalInput;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

     void FixedUpdate()
     {
        Vector2 newVelocity = new Vector2(horizontalInput * speed, body.velocity.y);
        body.velocity = newVelocity;
        float playerX = transform.localScale.x;

        if (horizontalInput < -0.01f)
        {
            if (Mathf.Sign(playerX) > 0)
                transform.localScale = new Vector3(-playerX, transform.localScale.y, transform.localScale.z);
        }
        else if (horizontalInput > 0.01f)
        {
            if (Mathf.Sign(playerX) < 0)
                transform.localScale = new Vector3(-playerX, transform.localScale.y, transform.localScale.z);
        }
    }

}
