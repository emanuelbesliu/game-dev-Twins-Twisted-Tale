﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class AntScript : MonoBehaviour
{
    public float Speed;

    public Tilemap tilemap;
    public HillHelp position;

    public bool up;
    public bool down;
    public bool left;
    public bool right;

    public bool help;
    public bool picked;
    private bool hasTurned = false;

    public bool stopEnemy;

    private float initialSpeed;

    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = this.transform.position;
        initialSpeed = Speed;
    }

    // Update is called once per frame
    void Update()
    {

        if(up){
            this.transform.position += Vector3.up * Time.deltaTime * Speed ;
        }

        if(down){
            this.transform.position += Vector3.down * Time.deltaTime * Speed ;
        }

        if(left){
            this.transform.position += Vector3.left * Time.deltaTime * Speed ;

        }

        if(right){
            this.transform.position += Vector3.right * Time.deltaTime * Speed ;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && stopEnemy && collision.gameObject.GetComponent<SlugScript>().direction != 0)
        {
            Speed = 0.5f;
            collision.gameObject.GetComponent<Animator>().SetBool("Stop", true);
            int oldD = collision.gameObject.GetComponent<SlugScript>().direction;
            collision.gameObject.GetComponent<SlugScript>().direction = 0;
            StartCoroutine(StopCounter(collision, oldD));
        }

        if(collision.gameObject.CompareTag("PickupAnt") && help){
            picked = true;
            if(this.transform.position.x >= -34f && this.transform.position.y < -10f){
                tilemap.SetTile(new Vector3Int(position.x, position.y, position.z), null);
                position.NextTile();
                tilemap.SetTile(new Vector3Int(position.x, position.y, position.z), null);
                position.NextTile();
            }
        }

        if (collision.gameObject.CompareTag("AntRespawn"))
        {
            up = false;
            down = false;
            right = false;
            left = false;

            this.transform.position = initialPosition;
        }

        if (collision.gameObject.CompareTag("AntUp"))
        {
            up = true;
        }else if (collision.gameObject.CompareTag("AntDown")){
            down = true;
        }else if (collision.gameObject.CompareTag("AntRight"))
        {
            right = true;
        }else if (collision.gameObject.CompareTag("AntLeft"))
        {
            left = true;
        }else if (collision.gameObject.CompareTag("AntOff")){
            collision.gameObject.SetActive(false);
            up = false;
            down = false;
            right = false;
            left = false;
        }else if(collision.gameObject.CompareTag("AntDownOff")){
            up = false;
            down = true;
            right = false;
            left = false;
        }else if(collision.gameObject.CompareTag("AntRightOff")){
            if(hasTurned){
                this.transform.Rotate(new Vector3(0,180,0));
                hasTurned = false;
            }
            up = false;
            down = false;
            right = true;
            left = false;
        }else if(collision.gameObject.CompareTag("AntUpOff")){
            up = true;
            down = false;
            right = false;
            left = false;
        }else if(collision.gameObject.CompareTag("AntLeftOff")){
            if(!hasTurned){
                this.transform.Rotate(new Vector3(0,180,0));
                hasTurned = true;
            }
            up = false;
            down = false;
            right = false;
            left = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickupAnt"))
        {
            picked = false;
        }

         if (collision.gameObject.CompareTag("Enemy") && stopEnemy)
        {
            Speed = initialSpeed;
        }
    }


    IEnumerator StopCounter(Collider2D collision, int oldDirection)
    {
        yield return new WaitForSeconds(5f);
        Debug.Log(oldDirection);
        collision.gameObject.GetComponent<Animator>().SetBool("Stop", false);
        collision.gameObject.GetComponent<SlugScript>().direction = oldDirection;
    }
}
