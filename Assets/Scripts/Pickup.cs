using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : ExtendedBehaviour
{

    private Inventory inventory;
    public GameObject itemButton;
    private bool canBePickedUp = false;
    Collider2D collided;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        
    }


    void pickup ()
    {
        if (collided.CompareTag("Player") && inventory.highlightedObject == this)
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    // You can add the item to the inventory

                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);

                    Destroy(gameObject);
                
                   break;
                }
            
             }

         }
     }
        
    


   

    void OnTriggerEnter2D(Collider2D other)
    {

       
        canBePickedUp = true;
        inventory.highlightedObject = this;
        collided = other;

    }
    void OnTriggerStay2D(Collider2D other)
    {
         /**
        if (inventory.highlightedObject == null)
        {
            canBePickedUp = true;
            inventory.highlightedObject = this;
            collided = other;
        }
    **/

    }
    void OnTriggerExit2D(Collider2D other)
    {
        inventory.highlightedObject = null;
        
        canBePickedUp = false;
        collided = null;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && canBePickedUp )
            pickup();
        if (inventory.highlightedObject != this)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1f);
        }
  
    }
}
