using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{

    private Inventory inventory;
    public HighlightInventory inventoryH;

    private int currentBlockSlot = 0;
    private GameObject currentBlock;

    private GameObject blockTemplate;
    private SpriteRenderer currentRend;

    public string keySlot;
   

    public int i;

    public GameObject shadowItem;
    private Transform player;
    private MovementPlatformer playerObject;

    private bool buildModeOn = false;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();

    }

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerObject = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementPlatformer>();
        inventoryH = GameObject.FindGameObjectWithTag("UI").GetComponent<HighlightInventory>();



    }



    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            shadowItem = child.GetComponent<Placeable>().SpawnDropItem();

            
            
        }
    }
    public void DestroyItem()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void HideItem()
    {
       if(shadowItem!= null) Destroy(shadowItem);
    }



    // Update is called once per frame
    void Update()
    {

        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }

        if (shadowItem != null)
        {
            if (playerObject.isLeft)
            {
                Vector2 playerPos = new Vector2(player.position.x - 3, player.position.y - 2.5f);
                shadowItem.transform.position = playerPos;
            }
            else
            {
                Vector2 playerPos = new Vector2(player.position.x + 3, player.position.y - 2.5f);
                shadowItem.transform.position = playerPos;
            }
            
            
        }

        /**
      if (Input.GetKeyDown(keySlot) && shadowItem != null)
      {

       Destroy(shadowItem);

      }

    
 
            if (Input.GetKeyDown(keySlot) && shadowItem == null)
            {
                DropItem();

            }
       

        if (Input.GetKeyDown("space") && shadowItem != null)
        {
            shadowItem = null;
            DestroyItem();
        }
    **/




    }



}
