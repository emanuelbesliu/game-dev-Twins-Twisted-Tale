using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public Pickup highlightedObject = null;

    public GameObject inventoryH;
    public bool isInvActive = true;

    void Start()
    {
        inventoryH = GameObject.FindGameObjectsWithTag("UI")[0];
    }

    void Update()
    {
        if (highlightedObject != null)
        {
            // TO DO : Highlight object

            //highlightedObject.gameObject.color.a = 0.5;
            highlightedObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);

        }

        if (Input.GetKeyDown("i"))
        {
            //Debug.Log("InvButtonFired");
            isInvActive = !isInvActive;
            inventoryH.SetActive(isInvActive);
            

        }


    }



}
