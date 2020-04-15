using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlatformer : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public SpriteRenderer sp;

    public bool canMove = false;
    public float speed = 10f;
    public float wallLerp = 10f;
    public bool ladderCollision = false;
    public bool ladder2Collision = false;

    private bool side = true;
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        //rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        /*if(x != 0){
            rigidbody.kinematic = false;
        }else{
            rigidbody.kinematic = true;
        }*/

        Vector2 direction =  new Vector2(x, y);

        Walk(direction);

        if((ladderCollision || ladder2Collision) && Input.GetButton("Up")){
            rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(rb.velocity.x, direction.y * speed)), wallLerp * Time.deltaTime);
            animator.SetBool("isWalking", true);
        }

        if((ladderCollision || ladder2Collision) && Input.GetButton("Down")){
            rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(rb.velocity.x, direction.y * speed)), wallLerp * Time.deltaTime);
            animator.SetBool("isWalking", true);
        }

        if(ladderCollision && (!Input.GetButton("Down") && !Input.GetButton("Up"))){
            animator.SetBool("isWalking", false);
           //Debug.Log("AICI");
        }

        if(!ladderCollision && (Input.GetButton("Down") || Input.GetButton("Up"))){
            animator.SetBool("isWalking", false);
        }

        if (x < 0 || x > 0 && canMove)
        {
            if(x > 0)   side = true;
            if(x < 0)   side = false;

            Flip(side);
        }
    }

    void Walk(Vector2 dir){
        if(!canMove)
            return;
        animator.SetFloat("Speed", Mathf.Abs(dir.x) * speed);
        rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(dir.x * speed, rb.velocity.y)), wallLerp * Time.deltaTime);
    }

    void Flip(bool side){
        if(!canMove){
            if (!side && sp.flipX)
                return;
            if (side && !sp.flipX)
                return;
        }

        bool state = (side) ? false : true;
        sp.flipX = state;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            ladderCollision = true;
        }else if (collision.gameObject.CompareTag("Ladder2"))
        {
            ladder2Collision = true;
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            ladderCollision = false;
        }else if (collision.gameObject.CompareTag("Ladder2"))
        {
            ladder2Collision = false;
        }
    }
}
