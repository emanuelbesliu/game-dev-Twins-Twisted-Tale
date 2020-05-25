using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : ExtendedBehaviour
{

    private Inventory inventory;
    public HighlightInventory inventoryH;
    public GameObject itemButton;
    private bool canBePickedUp = false;
    Collider2D collided;
    public AudioSource soundpickup;

    public int id = 0;
    // Start is called before the first frame update
    void Start()
    {
        try
        {


            soundpickup = GameObject.Find("PickupSound").GetComponent<AudioSource>();
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
            inventoryH = GameObject.FindGameObjectWithTag("UI").GetComponent<HighlightInventory>();
        }
        catch
        {

        }

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
                    if (soundpickup != null) soundpickup.Play();
                    Destroy(gameObject);
                
                   break;
                }
            
             }

         }
     }
        
    


   

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player")) {
            if (!inventoryH.isHighlighted) {
                canBePickedUp = true;
                inventory.highlightedObject = this;
                collided = other;
            }
            
        }


        

    }
    
    
    void OnTriggerStay2D(Collider2D other)
    {
        try
        {
            if (other.CompareTag("Player"))
            {
                if (!inventoryH.isHighlighted)
                {
                    canBePickedUp = true;
                    inventory.highlightedObject = this;
                    collided = other;
                }

            }
            if (inventoryH.isHighlighted)
            {
                inventory.highlightedObject = null;

                canBePickedUp = false;
                collided = null;
            }
            /**
            else if (!inventoryH.isHighlighted)
            {

                if (inventory.highlightedObject == null)
                {
                    canBePickedUp = true;
                    inventory.highlightedObject = this;
                    collided = other;
                }
            }
        **/
        }
        catch
        {

        }


        }
    void OnTriggerExit2D(Collider2D other)
    {
        try
        {

            inventory.highlightedObject = null;

            canBePickedUp = false;
            collided = null;
        }
        catch
        {

        }


    }

    // Update is called once per frame
    void Update()
    {
        try
        {



            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
            inventoryH = GameObject.FindGameObjectWithTag("UI").GetComponent<HighlightInventory>();
        }
        catch
        {

        }
        try
        {

            if (Input.GetKey(KeyCode.Space) && canBePickedUp)
                pickup();
            if (inventory.highlightedObject != this)
            {
                Color tmp = this.GetComponent<SpriteRenderer>().color;
                tmp.a = 1f;
                this.GetComponent<SpriteRenderer>().color = tmp;
            }

        }
        catch
        {

        }
        

    }
}
