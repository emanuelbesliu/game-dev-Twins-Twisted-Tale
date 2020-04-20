using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingObject

{
    private Animator animator;
    private Rigidbody2D rb2d;
    private int life = 3;
    public int speed = 5;
    public bool lookleft = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        base.Start();

    }
    protected override void AttemptMove<T>(int xDir, int yDir)
    {
        base.AttemptMove<T>(xDir, yDir);
        RaycastHit2D hit;

    }
    public void LoseLife(int playerDamage)
    {
        life -= playerDamage;
    }
    void Flip()
    {
        lookleft = !lookleft;
        Vector3 charscale = transform.localScale;
        charscale.x *= -1;
        transform.localScale = charscale;
    }



    // Update is called once per frame
    void Update()
    {
        var yVelocity = rb2d.velocity.y;
        if (yVelocity < -3) { animator.SetTrigger("isFalling"); rb2d.velocity = new Vector2(0f, rb2d.velocity.y); }

        Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal") * speed, 0f);

        // Movement Script
        if (Input.GetAxis("Horizontal") > 0 && yVelocity == 0)
        {

            animator.SetTrigger("isRunning");
            rb2d.velocity = move;

        }
        else if (Input.GetAxis("Horizontal") < 0 && yVelocity == 0)
        {


            animator.SetTrigger("isRunning");

            rb2d.velocity = move;

        }
        else  if (Input.GetAxis("Horizontal") == 0 )
        {
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
            animator.SetTrigger("isIdle");
        }
        /**
        horizontal = (int)Input.GetAxisRaw("Horizontal");
        vertical = (int)Input.GetAxisRaw("Vertical");

        if (horizontal != 0 )
        {
            AttemptMove<Breakable>(horizontal, 0);
            animator.SetTrigger("isRunning");
        }
        if (vertical != 0 )
        {

        }
    **/


    }
    void LateUpdate()
    {

        Vector3 localScale = transform.localScale;
        if (Input.GetAxisRaw("Horizontal") > 0)
        { lookleft = true; }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        { lookleft = false; }

        if (((lookleft) && (localScale.x < 0)) || ((!lookleft) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "clouds")
        {
            other.gameObject.SetActive(false);

        }
            

}

    protected override void OnCantMove <T> (T component)
    {
        Breakable hitWall = component as Breakable;
        hitWall.DamageWall(1);
        animator.SetTrigger("Break");
    }

}
