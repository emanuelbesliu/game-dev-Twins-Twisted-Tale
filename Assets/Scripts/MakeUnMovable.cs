using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeUnMovable : MonoBehaviour
{
    public GameObject slot4;


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("ShadowBlock"))
        {
            slot4 = other.gameObject;
            slot4.tag = "Collect";
            slot4.layer = LayerMask.NameToLayer("Ground");
            BoxCollider2D colliderBlock = slot4.GetComponent<BoxCollider2D>();
            other.isTrigger = false;
        }
            
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Collect"))
        {
            slot4 = other.gameObject;
            slot4.tag = "ShadowBlock";
            slot4.layer = LayerMask.NameToLayer("Default");


            other.isTrigger = true;
        }
    }



}
 
