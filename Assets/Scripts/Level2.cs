using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    public GameObject green;

    public GameObject guardianD;
    public GameObject guardianText1;
    public GameObject guardianText2;
    public GameObject guardianText3;
    public GameObject guardianText4;

    public GameObject antsD;
    public GameObject antsInfo;
    public GameObject antsText1;
    public GameObject antsText2;
    public GameObject antsText3;

    private bool firstAnts;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GuardianSpeech());
    }

    // Update is called once per frame
    void Update()
    {
         if(green.transform.position.y >= 4.2 && !firstAnts){
            firstAnts = true;
            antsD.SetActive(true);
        }

        if(antsInfo.activeSelf && Input.GetButtonDown("Info")){
            if(antsText1.activeSelf){
                antsText1.SetActive(false);
                antsText2.SetActive(true);
            }else if(antsText2.activeSelf){
                antsText2.SetActive(false);
                antsText3.SetActive(true);
                antsInfo.SetActive(false);
            }
        }
    }


    IEnumerator GuardianSpeech(){
        guardianD.SetActive(true);
        yield return new WaitForSeconds(10f);
        guardianD.SetActive(false);
        yield return new WaitForSeconds(15f);
        guardianD.SetActive(true);
        guardianText1.SetActive(false);
        guardianText2.SetActive(true);
        yield return new WaitForSeconds(7f);
        guardianD.SetActive(false);
        yield return new WaitForSeconds(5f);
        guardianD.SetActive(true);
        guardianText2.SetActive(false);
        guardianText4.SetActive(true);
        yield return new WaitForSeconds(20f);
        guardianD.SetActive(true);
        guardianText4.SetActive(false);
        guardianText3.SetActive(true);
    }
}
