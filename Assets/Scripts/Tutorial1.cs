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

    public GameObject nextTrigger;



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
            if (nextTip != null) nextTip.canBeActive = true;
           if (nextTrigger != null) nextTrigger.SetActive(true);
            Destroy(this);
           


        }
    }
}


