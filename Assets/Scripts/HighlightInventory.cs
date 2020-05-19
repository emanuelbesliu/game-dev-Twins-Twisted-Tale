using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighlightInventory : MonoBehaviour
{

    public bool isHighlighted = false;

    public Sprite noHighlightInventory;
    public Sprite inventory1;
    public Sprite inventory2;
    public Sprite inventory3;
    public Sprite inventory4;

    // Start is called before the first frame update
    void Start()
    {
        
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
            }

       

            else
            {
                this.gameObject.GetComponentInChildren<Image>().sprite = inventory1;
                isHighlighted = true;
            }
                
               

        }
            else
            if (Input.GetKeyDown("2"))
            {
            if (isHighlighted && this.gameObject.GetComponentInChildren<Image>().sprite == inventory2)
            {

                this.gameObject.GetComponentInChildren<Image>().sprite = noHighlightInventory;
                isHighlighted = false;
            }



            else
            {
                this.gameObject.GetComponentInChildren<Image>().sprite = inventory2;
                isHighlighted = true;
            }

        }
            else
            if (Input.GetKeyDown("3"))
            {
            if (isHighlighted && this.gameObject.GetComponentInChildren<Image>().sprite == inventory3)
            {

                this.gameObject.GetComponentInChildren<Image>().sprite = noHighlightInventory;
                isHighlighted = false;
            }



            else
            {
                this.gameObject.GetComponentInChildren<Image>().sprite = inventory3;
                isHighlighted = true;
            }
        }
            else
            if (Input.GetKeyDown("4"))
            {

            if (isHighlighted && this.gameObject.GetComponentInChildren<Image>().sprite == inventory4)
            {

                this.gameObject.GetComponentInChildren<Image>().sprite = noHighlightInventory;
                isHighlighted = false;
            }



            else
            {
                this.gameObject.GetComponentInChildren<Image>().sprite = inventory4;
                isHighlighted = true;
            }

        }
        

    }
}
