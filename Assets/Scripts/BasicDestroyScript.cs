using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDestroyScript : MonoBehaviour
{

    public GameObject objectToDestroy;
    public GameObject optionalItemToDisplay;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (objectToDestroy != null)
            {
                objectToDestroy.SetActive(false);

            }
            if (optionalItemToDisplay != null)
            {
                optionalItemToDisplay.SetActive(true);
            }
        }
    }
}

