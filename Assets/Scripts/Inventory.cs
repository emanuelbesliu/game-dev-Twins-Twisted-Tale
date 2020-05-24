using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public Pickup highlightedObject = null;
    public GameObject inventoryTip;
    public  Image imageInv;
    public HighlightInventory inventoryHigh;
    // public Image imageInvTip;

    public GameObject inventoryH;
    public bool isInvActive = true;

    void Start()
    {
        inventoryH = GameObject.FindGameObjectsWithTag("UI")[0];
        inventoryHigh = GameObject.FindGameObjectWithTag("UI").GetComponent<HighlightInventory>();
        imageInv = inventoryH.GetComponent<Image>();
        //imageInvTip = inventoryTip.GetComponent<Image>();

    }

    
    void Update()
    {
        if (highlightedObject != null)
        {
            // TO DO : Highlight object

            //highlightedObject.gameObject.color.a = 0.5;
            highlightedObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);

        }


        // inventoryH.SetActive(isInvActive);
        try
        {
            imageInv = inventoryH.GetComponent<Image>();
            var tempColor = imageInv.color;
            if (isInvActive)
            {
                tempColor.a = 1f;
                inventoryHigh.setAlpha(1f);
                inventoryTip.SetActive(false);


            }
            else
            {
                tempColor.a = 0f; inventoryHigh.setAlpha(0f);
                 inventoryTip.SetActive(true);
            }

            imageInv.color = tempColor;



        }

        catch { }

        if (Input.GetKeyDown("e"))
        {
            //Debug.Log("InvButtonFired");
            isInvActive = !isInvActive;
           
 
            
 
            
            
           

        }


    }



}
