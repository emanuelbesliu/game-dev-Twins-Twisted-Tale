using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HighlightInventory : MonoBehaviour
{

    public bool isHighlighted = false;
   
    private GameObject inventoryRef;

   // public Color currentBlockColor;

    public Sprite noHighlightInventory;
    public Sprite inventory1;
    public Sprite inventory2;
    public Sprite inventory3;
    public Sprite inventory4;

    public float offsetxInv;
    public float offsetyInv;

    public BuildSystem slot1;
    public BuildSystem slot2;
    public BuildSystem slot3;
    public BuildSystem slot4;

    public AudioSource soundSelectItem;
    public AudioSource soundDeselectItem;
    public AudioSource soundbuild;
    public AudioSource soundbuildNot;

    public bool[] canPlace = new bool[6];
    
    public int currentSlot = 0;



    // Start is called before the first frame update
    void Start()
    {
     canPlace[1] = true;
     canPlace[2] = true;
     canPlace[3] = true;
     canPlace[4] = true;
    inventoryRef = this.gameObject;
    }
    public void setAlpha(float alpha)
    {
        Color newColor;

        Image[] childrenImg = GetComponentsInChildren<Image>();
        foreach (Image img in childrenImg)
        {
            newColor = img.color;
            newColor.a = alpha;
            img.color = newColor;
        }
        Text[] childrenText = GetComponentsInChildren<Text>();
        foreach (Text text in childrenText)
        {
            newColor = text.color;
            newColor.a = alpha;
            text.color = newColor;
        }

        soundSelectItem = GameObject.Find("InventorySelect").GetComponent<AudioSource>();
        soundSelectItem = GameObject.Find("InventoryDeselect").GetComponent<AudioSource>();
        soundbuild = GameObject.Find("BuildSound").GetComponent<AudioSource>();
        soundbuildNot = GameObject.Find("InventoryNotAllowed").GetComponent<AudioSource>();
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
                if (soundDeselectItem != null) soundDeselectItem.Play();
            }

       

            else
            {
                slot2.HideItem();
                slot3.HideItem();
                slot4.HideItem();
                slot1.DropItem();
                if (soundSelectItem != null) soundSelectItem.Play();
                this.gameObject.GetComponentInChildren<Image>().sprite = inventory1;
                currentSlot = 1;
                isHighlighted = true;
            }
                
               

        }
            else
            if (Input.GetKeyDown("2"))
            {
            if (isHighlighted && this.gameObject.GetComponentInChildren<Image>().sprite == inventory2)
            {
                if (soundDeselectItem != null) soundDeselectItem.Play();

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
                if (soundSelectItem != null) soundSelectItem.Play();
                this.gameObject.GetComponentInChildren<Image>().sprite = inventory2;
                currentSlot = 2;
                isHighlighted = true;
            }

        }
            else
            if (Input.GetKeyDown("3"))
            {
            if (isHighlighted && this.gameObject.GetComponentInChildren<Image>().sprite == inventory3)
            {
                if (soundDeselectItem != null) soundDeselectItem.Play();
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
                if (soundSelectItem != null) soundSelectItem.Play();
                this.gameObject.GetComponentInChildren<Image>().sprite = inventory3;
                currentSlot = 3;
                isHighlighted = true;
            }
        }
            else
            if (Input.GetKeyDown("4"))
            {

            if (isHighlighted && this.gameObject.GetComponentInChildren<Image>().sprite == inventory4)
            {
                if (soundDeselectItem != null) soundDeselectItem.Play();
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
                if (soundSelectItem != null) soundSelectItem.Play();
                this.gameObject.GetComponentInChildren<Image>().sprite = inventory4;
                currentSlot = 4;
                isHighlighted = true;
            }

        }

            else 
            if (Input.GetKeyDown("space"))
        {
            if (slot1.shadowItem != null && canPlace[1] )
            {
                if (soundbuild != null) soundbuild.Play();
                slot1.shadowItem.tag = "Collect";
                slot1.DestroyItem();
                
                slot1.shadowItem = null;
                this.gameObject.GetComponentInChildren<Image>().sprite = noHighlightInventory;
                isHighlighted = false;

            }
            else if (slot1.shadowItem != null && !canPlace[1])
            {
                if (soundbuildNot != null) soundbuildNot.Play();
                Debug.Log("Cannot Place current item");
            }
            else
            if (slot2.shadowItem != null && canPlace[2] )
            {
                if (soundbuild != null) soundbuild.Play();
                slot2.DestroyItem();
                slot2.shadowItem.tag = "Collect";
                slot2.shadowItem = null;
                this.gameObject.GetComponentInChildren<Image>().sprite = noHighlightInventory;
                isHighlighted = false;

            }
            
            else if (slot2.shadowItem != null && !canPlace[2])
            {
                if (soundbuildNot != null) soundbuildNot.Play();
                Debug.Log("Cannot Place current item");
            }
            else if (slot3.shadowItem != null && canPlace[3])
            {
                if (soundbuild != null) soundbuild.Play();
                slot3.DestroyItem();
                slot3.shadowItem.tag = "Collect";
                slot3.shadowItem = null;
                this.gameObject.GetComponentInChildren<Image>().sprite = noHighlightInventory;
                isHighlighted = false;

            }
            else if (slot3.shadowItem != null && !canPlace[3])
            {
                if (soundbuildNot != null) soundbuildNot.Play();
                Debug.Log("Cannot Place current item");
            }
            else
            if (slot4.shadowItem != null && canPlace[4])
            {
                if (soundbuild != null) soundbuild.Play();
                slot4.DestroyItem();
                slot4.shadowItem.tag = "Collect";
                slot4.shadowItem = null;
                this.gameObject.GetComponentInChildren<Image>().sprite = noHighlightInventory;
                isHighlighted = false;

            }
            else if (slot4.shadowItem != null && !canPlace[4])
            {
                if (soundbuildNot != null) soundbuildNot.Play();
                Debug.Log("Cannot Place current item");
            }
            
        }
        

    }
}
