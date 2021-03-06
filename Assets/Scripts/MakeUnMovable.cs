﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MakeUnMovable : MonoBehaviour
{
    public GameObject slot4;
    public GameObject firstBridgePart;
    public GameObject secondBridgePart;
    private Collider2D other;
    public HighlightInventory inventoryH;
    public int idWeLookFor;
    private int currentId;
    public bool premadeBridge = false;

    void Start()
    {
        inventoryH = GameObject.FindGameObjectWithTag("UI").GetComponent<HighlightInventory>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        
        if (other != null && other.CompareTag("ShadowBlock"))
        {
            this.other = other;
            slot4 = other.gameObject;
            try
            {
                Pickup currentObject = GameObject.FindGameObjectWithTag("ShadowBlock").GetComponent<Pickup>();
                currentId = currentObject.id;

            }
            catch
            { }

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
    void Update()
    {
        
        if (Input.GetKey("space"))
        {
            //Debug.Log("Should update platform");

            if (firstBridgePart != null && secondBridgePart != null)
            {
                if (!secondBridgePart.activeSelf)
                {
                    if (firstBridgePart.activeSelf) firstBridgePart.GetComponent<BoxCollider2D>().enabled = false;
                }
                else { firstBridgePart.GetComponent<BoxCollider2D>().enabled = true; }

                if (other != null)
                {
                    if (premadeBridge)
                    {
                        if (other.CompareTag("Collect") && idWeLookFor == currentId)
                        {
                            slot4 = other.gameObject;
                            slot4.SetActive(false);
                            if (firstBridgePart.activeSelf)
                            {
                                secondBridgePart.SetActive(true);
                                other = null;
                            }

                            firstBridgePart.SetActive(true);
                            other = null;


                        }
                    }
                    if (other != null)
                    {
                        if (SceneManager.GetActiveScene().name == "Level1-2G" || SceneManager.GetActiveScene().name == "Level1-2L" || SceneManager.GetActiveScene().name == "Level1-2N")
                        { // Trigger for level 1.3
                            if (other.CompareTag("Collect") && idWeLookFor == currentId)
                            {
                                slot4 = other.gameObject;
                                slot4.SetActive(false);
                                if (firstBridgePart.activeSelf)
                                {
                                    secondBridgePart.SetActive(true);
                                    other = null;
                                }

                                firstBridgePart.SetActive(true);
                                other = null;


                            }
                        }

            }

                }
            }
        }

    }



}
 
