using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private Animator anim;
    private MovementPlatformer move;
    private Collision coll;
    public SpriteRenderer sp;


    void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponentInParent<Collision>();
        move = GetComponentInParent<MovementPlatformer>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("OnGround", coll.onGround);
        anim.SetBool("WallGrab", move.wallGrab);
        anim.SetBool("CanMove", move.canMove);
    }


    public void SetHorizontalMovement(float x, float y, float yVel)
    {
        anim.SetFloat(("HorizontalAxis"), Mathf.Abs(x));
        anim.SetFloat(("VerticalAxis"), y);
        anim.SetFloat(("VerticalVelocity"), yVel);
    }

    public void SetTrigger(string trigger)
    {
        anim.SetTrigger(trigger);
    }

    public void Flip(bool side)
    {
        if (move.wallGrab)
        {
            if (!side && sp.flipX)
                return;
            if (side && !sp.flipX)
                return;

        }

        bool state = (side) ? false : true;
        sp.flipX = state;
    }
}
