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


    private bool buildModeOn = false;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("e"))
        {
            buildModeOn = !buildModeOn;

            if (blockTemplate != null)
            {
                Destroy(blockTemplate);

            }


            if (currentBlock == null)
            {
                if (inventory.slotsO[currentBlockSlot] != null)
                {
                    currentBlock = inventory.slotsO[currentBlockSlot];
                }

            }

            if (buildModeOn)
            {
                // Create template of to be placed block.
                Debug.Log("Building");
              

                blockTemplate = new GameObject("currentBlockTemplate");

                // Rendering the sprite of the block.
                currentRend = blockTemplate.AddComponent<SpriteRenderer>();
              //  currentRend.sprite = currentBlock.blockSprite;

                

            }
        }

        
    }
}
