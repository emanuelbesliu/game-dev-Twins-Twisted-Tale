using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTutorial : MonoBehaviour
{
    public GameObject dialogue;
    public GameObject dialogue2;
    public GameObject dialogue3;
    public GameObject dialogue4;
    public GameObject forcedTrigger;
    public Rigidbody2D flowerToTest;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        dialogue.SetActive(true);


        yield return new WaitForSeconds(5);
        dialogue.SetActive(false);

        dialogue2.SetActive(true);
        yield return new WaitForSeconds(3);
        flowerToTest.isKinematic = false;
        dialogue2.SetActive(false);
        dialogue3.SetActive(true);


        yield return new WaitForSeconds(1);
        if (forcedTrigger != null) { forcedTrigger.SetActive(true); flowerToTest.gameObject.SetActive(false); }

        yield return new WaitForSeconds(5);
        dialogue3.SetActive(false);

        dialogue4.SetActive(true);
        yield return new WaitForSeconds(3);
        
        Destroy(this.gameObject);
   
    }


}
