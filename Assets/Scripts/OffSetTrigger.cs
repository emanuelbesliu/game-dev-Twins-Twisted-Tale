﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OffSetTrigger : MonoBehaviour
{
    public HighlightInventory inventoryH;
    public Pickup currentObject;

    private float savedX = 3f;
    private float savedY = -0.4f;
    public bool doesLeftMatter1 = true;

    public bool can1bePlaced = true;
    public float customX;
    public float customY;


    public bool doesLeftMatter2 = true;
    public bool can2bePlaced = true;

    public float customX2;
    public float customY2;

    public bool doesLeftMatter3 = true;
    public bool can3bePlaced = true;

    public float customX3;
    public float customY3;

    private MovementPlatformer playerObject;


    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementPlatformer>();
        inventoryH = GameObject.FindGameObjectWithTag("UI").GetComponent<HighlightInventory>();
    }

    GameObject FindClosestBlock()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("ShadowBlock");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = playerObject.gameObject.transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
    void Update()
    {
        if (currentObject != null && currentObject.id == 6) inventoryH.canPlace[inventoryH.currentSlot] = false;
    }

// Trigger the changing of the offset variables to proper sizes;

void OnTriggerStay2D(Collider2D other)
    {
        try { currentObject = FindClosestBlock().GetComponent<Pickup>(); }
        catch
        { }
        

       

        if (other.CompareTag("Player") && currentObject != null && currentObject.id != 6 )
        {
           

            // ---- Object with ID 1 offset ----
      
                if (currentObject != null && currentObject.id == 1)
                {
               

                inventoryH.offsetxInv = customX;
                inventoryH.offsetyInv = customY;

                if (!can1bePlaced)
                {
                    //Debug.Log("Color Should change");
                    
                    currentObject.GetComponent<SpriteRenderer>().color = new Color(1f, 28f/255f, 28f/255f, 1f);
                    inventoryH.canPlace[inventoryH.currentSlot] = false;
                   

                }
                    else
                {
                   
                    currentObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                    inventoryH.canPlace[inventoryH.currentSlot] = true;
                   
                }
                    
            }
            // ---- Object with ID 1 offset END ----


            // ---- Object with ID 2 offset ----
            if (currentObject != null && currentObject.id == 2)


                {

               
                if (!can2bePlaced)
                {
                 //   Debug.Log("Color Should change");
                 
                    currentObject.GetComponent<SpriteRenderer>().color = new Color(1f, 28f / 255f, 28f / 255f, 1f);
                    inventoryH.canPlace[inventoryH.currentSlot] = false;

                }
                else
                {
                   
                    currentObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                    inventoryH.canPlace[inventoryH.currentSlot] = true;
                   
                }
                    inventoryH.offsetxInv = customX2;
                    inventoryH.offsetyInv = customY2;
                }

            // ---- Object with ID 2 END ----

            // ---- Object with ID 3 offset ----



            if (currentObject != null && currentObject.id == 3)


                {

                
                if (!can3bePlaced)
                {
                 //   Debug.Log("Color Should change");
                 
                    currentObject.GetComponent<SpriteRenderer>().color = new Color(1f, 28f / 255f, 28f / 255f, 1f);
                    inventoryH.canPlace[inventoryH.currentSlot] = false;

                }
                else

                {
                   
                    currentObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                    inventoryH.canPlace[inventoryH.currentSlot] = true;
                   
                }
                    inventoryH.offsetxInv = customX3;
                    inventoryH.offsetyInv = customY3;
                }

            // ---- Object with ID 3  END ----




        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        
        try
        {
            if (currentObject.id != 6)
            {
                currentObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

                inventoryH.canPlace[inventoryH.currentSlot] = true;
            }

            if (currentObject.id == 6) inventoryH.canPlace[inventoryH.currentSlot] = false;
            
            if (currentObject != null)
            {
               // inventoryH.offsetxInv = savedX;
               // inventoryH.offsetyInv = savedY;
            }
        }
        catch { }
        
    }


}
