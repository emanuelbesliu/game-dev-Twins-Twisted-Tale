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
    public bool doesLeftMatter = true;

    public bool can1bePlaced = true;
    public float customX;
    public float customY;

    public bool can2bePlaced = true;

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
        if (playerObject.isLeft && doesLeftMatter)
        {
           // inventoryH.offsetxInv = savedX;
          //  inventoryH.offsetyInv = savedY;
        }



        if (other.CompareTag("Player"))
        {
            
           
                //Debug.Log(currentObject.id);
                if (currentObject != null && currentObject.id == 1)
                {

                inventoryH.offsetxInv = customX;
                inventoryH.offsetyInv = customY;

                if (!can1bePlaced)
                {
                    Debug.Log("Color Should change");
                    
                    currentObject.GetComponent<SpriteRenderer>().color = new Color(1f, 28f/255f, 28f/255f, 1f);
                    inventoryH.canPlace[inventoryH.currentSlot] = false;
                   

                }
                    else
                {
                   
                    currentObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                    inventoryH.canPlace[inventoryH.currentSlot] = true;
                   
                }
                    
            }

                if (currentObject != null && currentObject.id == 2)


                {
                if (!can2bePlaced)
                {
                    Debug.Log("Color Should change");
                 
                    currentObject.GetComponent<SpriteRenderer>().color = new Color(1f, 28f / 255f, 28f / 255f, 1f);
                  

                }
                else
                {
                   
                    currentObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                    inventoryH.canPlace[inventoryH.currentSlot] = true;
                   
                }
                    inventoryH.offsetxInv = customX2;
                    inventoryH.offsetyInv = customY2;
                }

            


        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        
        try
        {
            currentObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            inventoryH.canPlace[inventoryH.currentSlot] = true;
            if (currentObject != null)
            {
                inventoryH.offsetxInv = savedX;
                inventoryH.offsetyInv = savedY;
            }
        }
        catch { }
        
    }


}
