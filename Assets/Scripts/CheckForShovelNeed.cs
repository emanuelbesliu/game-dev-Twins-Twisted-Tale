using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForShovelNeed : MonoBehaviour
{
    public GameObject antHelp;
    public GameObject shovelItems;
    public GameObject dialogueLines;
    // Start is called before the first frame update
    void Awake()
    {
        if (!antHelp.activeSelf)
        {
            shovelItems.SetActive(true);
            dialogueLines.SetActive(true);

        }
        else
        {
            shovelItems.SetActive(false);
            dialogueLines.SetActive(false);
        }
        
    }

}
