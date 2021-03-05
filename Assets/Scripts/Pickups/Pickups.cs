using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public enum CollectibleType
    {
        POWERUP,
        COLLECTIBLE,
        LIVES,
        KEY
    }

    public CollectibleType currentCollectible;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (currentCollectible)
            {
                case CollectibleType.POWERUP:
                    Debug.Log("PowerUp");
                    collision.GetComponent<PlayerMovement>().StartJumpForceChange();
                    Destroy(gameObject);
                    break;
                case CollectibleType.LIVES:
                    Debug.Log("Lives");
                    GameManager.instance.lives++;
                    Destroy(gameObject);
                    break;
                case CollectibleType.COLLECTIBLE:
                    Debug.Log("Collectible");
                    GameManager.instance.score++;
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
