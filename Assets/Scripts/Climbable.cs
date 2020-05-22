using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbable : MonoBehaviour
{
    public BoxCollider2D climbObject;
    // Start is called before the first frame update

    private bool noMoreUp = false;
    private bool noMoreDown = true;
    private Transform player;
    private Transform platformTransform;
    void Start()
    {
        climbObject = this.GetComponent<BoxCollider2D>();
        platformTransform = this.GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            climbObject.isTrigger = false;
            // noMoreUp = !noMoreUp;
            // noMoreDown = !noMoreDown; 
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetButton("Up") && !noMoreUp)
        {
            climbObject.isTrigger = true;
            gameObject.layer = LayerMask.NameToLayer("Default");
            // noMoreUp = true;
            Debug.Log("Should Pass now");
            if (player.position.y > platformTransform.position.y - 0.2 && !Input.GetButton("Down"))
            {
                gameObject.layer = LayerMask.NameToLayer("Ground");
                noMoreUp = true;
                noMoreDown = false;

            }


        }
        if (Input.GetButton("Down") && !noMoreDown)
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
            Debug.Log("ShouldClimbDown");
            climbObject.isTrigger = true;
            //noMoreDown = true;
            noMoreDown = true;
            noMoreUp = false;




        }

    }
}
