using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial2 : MonoBehaviour
{

        public bool canBeActive;
        public GameObject objectTocheck;
        public GameObject optionalPreviousTutorialTip;
        public GameObject afterBrokeBlock;

        public GameObject objectToBeDisplayed;



        
        void Update()
        {

            if (objectTocheck == null && canBeActive)
            {
                if (Input.GetKeyDown("1"))
            {
                if (optionalPreviousTutorialTip != null) optionalPreviousTutorialTip.SetActive(false);
                canBeActive = false;
                objectToBeDisplayed.SetActive(true);

            }
                



            }
        }
    



}
