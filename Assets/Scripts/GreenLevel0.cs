using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenLevel0 : MonoBehaviour
{
    public Level0Trans script;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            script.ladderCollisionGreen = true;

        }else if(collision.gameObject.CompareTag("Ladder2")){
            script.ladderCollisionGreen = false;
            script.ladderCollision2Green = true;
        }
    }
}
