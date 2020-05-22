using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MakeUnMovable : MonoBehaviour
{
    public GameObject slot4;
    public GameObject firstBridgePart;
    public GameObject secondBridgePart;
    private Collider2D other;



    void OnTriggerStay2D(Collider2D other)
    {
        this.other = other;

        if (other.CompareTag("ShadowBlock"))
        {
            slot4 = other.gameObject;
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
    { if (other != null)
        {
            if (SceneManager.GetActiveScene().name == "Level1-2G" || SceneManager.GetActiveScene().name == "Level1-2L&N")
            { // Trigger for level 1.3
                if (other.CompareTag("Collect") && Input.GetKey("space"))
                {
                    slot4 = other.gameObject;
                    slot4.SetActive(false);
                    if (firstBridgePart.activeSelf) secondBridgePart.SetActive(true);
                    firstBridgePart.SetActive(true);


                }
            }
        }

    }



}
 
