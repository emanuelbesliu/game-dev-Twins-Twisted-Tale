using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OffSetTrigger : MonoBehaviour
{
    public HighlightInventory inventoryH;
    public Pickup currentObject;

    private float savedX = 3f;
    private float savedY = -0.4f;


    public float customX;
    public float customY;

    public float customX2;
    public float customY2;

    private MovementPlatformer playerObject;


    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementPlatformer>();
        inventoryH = GameObject.FindGameObjectWithTag("UI").GetComponent<HighlightInventory>();
    }

    // Trigger the changing of the offset variables to proper sizes;

    void OnTriggerStay2D(Collider2D other)
    {
        try { currentObject = GameObject.FindGameObjectWithTag("ShadowBlock").GetComponent<Pickup>(); }
        catch
        { }



            if (other.CompareTag("Player"))
        {
            
           
                //Debug.Log(currentObject.id);
                if (currentObject.id == 1)
                {
                    inventoryH.offsetxInv = customX;
                    inventoryH.offsetyInv = customY;
                }

                if (currentObject.id == 2)
                {
                    inventoryH.offsetxInv = customX2;
                    inventoryH.offsetyInv = customY2;
                }

            


        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        inventoryH.offsetxInv = savedX;
        inventoryH.offsetyInv = savedY;
    }


            // Update is called once per frame
    void Update()
    { 
        try
        {
            playerObject = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementPlatformer>();
        }
        catch
        {

        }

        if (playerObject.isLeft)
        {
            inventoryH.offsetxInv = savedX;
            inventoryH.offsetyInv = savedY;
        }
    }
}
