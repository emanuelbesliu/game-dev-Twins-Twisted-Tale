﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLevel0 : MonoBehaviour
{
    public Level0Trans script;
    public GameObject rocket1;
    public GameObject rocket2;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder") && script.no)
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 0;
            script.ladderCollision = true;
            script.animatorRed.SetFloat("HorizontalAxis", 0);
            script.runRed = false;

        }else if(collision.gameObject.CompareTag("Ladder2") && script.no){
            script.ladderCollision = false;
            script.ladderCollision2 = true;
            this.gameObject.SetActive(false);
            rocket1.gameObject.SetActive(false);
            rocket2.gameObject.SetActive(true);
        }
    }
}
