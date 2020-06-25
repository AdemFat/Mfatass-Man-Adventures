using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceBehaviour : MonoBehaviour
{
    public int health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().KillMeAfterAwhile();
            health--;
            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<PlayerMovement>().DontKillMe();
    }

}
