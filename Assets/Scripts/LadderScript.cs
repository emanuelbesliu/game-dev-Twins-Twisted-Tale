using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    private MovementPlatformer playerObject;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementPlatformer>();
    }
 
    void OnTriggerExit2D (Collider2D other)
    {
        if (!playerObject.coll.onGround)
        {
            playerObject.rb.velocity = new Vector2(0, playerObject.rb.velocity.y);
            playerObject.animator.SetBool("Climb", true);
            playerObject.animator.SetBool("isWalking", false);
            playerObject.rb.gravityScale = 4;
        }
        else
        {
            playerObject.animator.SetBool("isWalking", false);
            playerObject.animator.SetBool("Climb", false);
        }


    }

    void OnTriggerStay2D (Collider2D other)
    {
        if (other.CompareTag("Player") ){
            playerObject.ladderCollision = true;
        }


    }

}
