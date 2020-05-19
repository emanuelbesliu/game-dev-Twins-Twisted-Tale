using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public Pickup highlightedObject = null;

    void Update()
    {
        if (highlightedObject != null)
        {
            // TO DO : Highlight object

            //highlightedObject.gameObject.color.a = 0.5;
            highlightedObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);

        }


    }



}
