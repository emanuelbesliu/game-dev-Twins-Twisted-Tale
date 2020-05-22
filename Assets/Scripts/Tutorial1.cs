using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial1 : MonoBehaviour
{
    public GameObject objectToBeDisplayed;
    public GameObject objectWhenToDestroyTip;
    public GameObject optionalPreviousTutorialTip;
    public GameObject afterBrokeBlock;
    public Tutorial2 nextTip;



    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.CompareTag("Player")) {
            if (optionalPreviousTutorialTip != null) optionalPreviousTutorialTip.SetActive(false);
            objectToBeDisplayed.SetActive(true);



        }


    }
    void Update()
    { 

        if (objectWhenToDestroyTip == null)
        {
            objectToBeDisplayed.SetActive(false);
          if (afterBrokeBlock != null)  afterBrokeBlock.SetActive(true);
            nextTip.canBeActive = true;
            Destroy(this);
           


        }
    }
}


