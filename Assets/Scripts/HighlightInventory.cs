using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighlightInventory : MonoBehaviour
{

    public bool isHighlighted = false;
   
    private GameObject inventoryRef;

    public Sprite noHighlightInventory;
    public Sprite inventory1;
    public Sprite inventory2;
    public Sprite inventory3;
    public Sprite inventory4;

    public BuildSystem slot1;
    public BuildSystem slot2;
    public BuildSystem slot3;
    public BuildSystem slot4;



    // Start is called before the first frame update
    void Start()
    {
        inventoryRef = this.gameObject;
    }

    // Updating the Inventory highlight
    void Update()
    {
        
        

            if (Input.GetKeyDown("1"))
            {
            
            if (isHighlighted && this.gameObject.GetComponentInChildren<Image>().sprite == inventory1)
            {
                
                this.gameObject.GetComponentInChildren<Image>().sprite = noHighlightInventory;
                isHighlighted = false;
                slot1.HideItem();
            }

       

            else
            {
                slot2.HideItem();
                slot3.HideItem();
                slot4.HideItem();
                slot1.DropItem();
                this.gameObject.GetComponentInChildren<Image>().sprite = inventory1;
                isHighlighted = true;
            }
                
               

        }
            else
            if (Input.GetKeyDown("2"))
            {
            if (isHighlighted && this.gameObject.GetComponentInChildren<Image>().sprite == inventory2)
            {

                slot2.HideItem();
                this.gameObject.GetComponentInChildren<Image>().sprite = noHighlightInventory;
                isHighlighted = false;
            }



            else
            {
                slot1.HideItem();
                slot3.HideItem();
                slot4.HideItem();
                slot2.DropItem();
                this.gameObject.GetComponentInChildren<Image>().sprite = inventory2;
                isHighlighted = true;
            }

        }
            else
            if (Input.GetKeyDown("3"))
            {
            if (isHighlighted && this.gameObject.GetComponentInChildren<Image>().sprite == inventory3)
            {
                slot3.HideItem();
                this.gameObject.GetComponentInChildren<Image>().sprite = noHighlightInventory;
                isHighlighted = false;
            }



            else
            {
                slot2.HideItem();
                slot1.HideItem();
                slot4.HideItem();
                slot3.DropItem();
                this.gameObject.GetComponentInChildren<Image>().sprite = inventory3;
                isHighlighted = true;
            }
        }
            else
            if (Input.GetKeyDown("4"))
            {

            if (isHighlighted && this.gameObject.GetComponentInChildren<Image>().sprite == inventory4)
            {
                slot4.HideItem();
                this.gameObject.GetComponentInChildren<Image>().sprite = noHighlightInventory;
                isHighlighted = false;
            }



            else
            {
                slot2.HideItem();
                slot3.HideItem();
                slot1.HideItem();
                slot4.DropItem();
                this.gameObject.GetComponentInChildren<Image>().sprite = inventory4;
                isHighlighted = true;
            }

        }

            else 
            if (Input.GetKeyDown("space"))
        {
            if (slot1.shadowItem != null)
            {
                slot1.DestroyItem();
                slot1.shadowItem = null;
                this.gameObject.GetComponentInChildren<Image>().sprite = noHighlightInventory;
                isHighlighted = false;

            }
            else 
            if (slot2.shadowItem != null)
            {
                slot2.DestroyItem();
                slot2.shadowItem = null;
                this.gameObject.GetComponentInChildren<Image>().sprite = noHighlightInventory;
                isHighlighted = false;

            }
            else 
            if (slot3.shadowItem != null)
            {
                slot3.DestroyItem();
                slot3.shadowItem = null;
                this.gameObject.GetComponentInChildren<Image>().sprite = noHighlightInventory;
                isHighlighted = false;

            }
            else 
            if (slot4.shadowItem != null)
            {
                slot4.DestroyItem();
                slot4.shadowItem = null;
                this.gameObject.GetComponentInChildren<Image>().sprite = noHighlightInventory;
                isHighlighted = false;

            }
            
        }
        

    }
}
