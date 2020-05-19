using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{

    private Inventory inventory;

    private int currentBlockSlot = 0;
    private GameObject currentBlock;

    private GameObject blockTemplate;
    private SpriteRenderer currentRend;

    public string keySlot;
   

    public int i;



    private bool buildModeOn = false;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();

    }

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
       

    }



    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Placeable>().SpawnDropItem();
            GameObject.Destroy(child.gameObject);
            

        }
    }

  

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }



        if (Input.GetKeyDown(keySlot))
        {
            DropItem();
           
        }

        
    }
}
