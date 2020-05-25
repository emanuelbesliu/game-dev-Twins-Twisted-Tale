using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLevel0 : MonoBehaviour
{
    public Level0Trans script;
    public Level1 scriptL1;
    public Rigidbody2D fallingPlatform0;

    public GameObject rocket1;
    public GameObject rocket2;

    private bool fall = false;
    private bool firstCollision = false;
    void OnTriggerEnter2D(Collider2D collision)
    { try
        {
            if (collision.gameObject.CompareTag("Ladder") && script.no)
            {
                this.GetComponent<Rigidbody2D>().gravityScale = 0;
                script.ladderCollision = true;
                script.animatorRed.SetFloat("HorizontalAxis", 0);
                script.runRed = false;

            }
            else if (collision.gameObject.CompareTag("Ladder2") && script.no)
            {
                script.ladderCollision = false;
                script.ladderCollision2 = true;
                this.gameObject.SetActive(false);
                rocket1.gameObject.SetActive(false);
                rocket2.gameObject.SetActive(true);
            }
            else if (collision.gameObject.CompareTag("Stop") && !firstCollision)
            {
                firstCollision = true;
                scriptL1.redRun = false;
                scriptL1.animatorRed.SetFloat("HorizontalAxis", Mathf.Abs(0));
                GetComponent<SpriteRenderer>().flipX = true;
                fall = true;
                scriptL1.endRunRed = true;
            }
        }
        catch { }
    }

    void Update(){
        if (fallingPlatform0 != null)
        {
            if (fall)
            {
                //if(fallingPlatform0.gravityScale == 0)
                fallingPlatform0.gravityScale += 1f;
            }

            if (fallingPlatform0.gravityScale > 8)
            {
                fall = false;
            }
        }
    }
}
