using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerCollision : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerMovement pm;

    public float bounceForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<PlayerMovement>();

        if (bounceForce <= 0)
        {
            bounceForce = 20.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.gameObject.tag == "Squished")
        {
            if (!pm.isGrounded)
            {
                collison.gameObject.GetComponentInParent<EnemyWalker>().IsSquished();
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * bounceForce);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            GameManager.instance.lives--;
            Destroy(collision.gameObject);
            
        }

        if (collision.gameObject.tag == "Enemy")
        {
            GameManager.instance.lives--;
            //if lives are > 0 - respawn and continue the level
        }
    }
}
