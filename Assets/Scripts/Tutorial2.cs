using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial2 : MonoBehaviour
{

        public bool canBeActive;
        public GameObject objectTocheck;
        public GameObject optionalPreviousTutorialTip;
        public GameObject nextTutorial;

        public GameObject objectToBeDisplayed;



        
        void Update()
        {

            if (objectTocheck == null && canBeActive)
            {
                
                if (optionalPreviousTutorialTip != null) optionalPreviousTutorialTip.SetActive(false);
                canBeActive = false;
               if (objectToBeDisplayed != null) objectToBeDisplayed.SetActive(true);
                if (nextTutorial != null) nextTutorial.SetActive(true);

            
                



            }
        }
    



}
