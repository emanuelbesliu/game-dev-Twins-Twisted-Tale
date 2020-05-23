using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{

    private Inventory inventory;
    private HighlightInventory inventoryH;


    private GameObject currentBlock;

    private GameObject blockTemplate;
    private SpriteRenderer currentRend;

    public string keySlot;
   

    public int i;

    public GameObject shadowItem;
    private Transform player;
    private MovementPlatformer playerObject;
    private float offsetx = 3f;
    private float offsety = -2.5f;

 

    private void Awake()
    {
        inventory = GetComponent<Inventory>();

    }

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
            player = GameObject.FindGameObjectWithTag("Player").transform;
            playerObject = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementPlatformer>();
            inventoryH = GameObject.FindGameObjectWithTag("UI").GetComponent<HighlightInventory>();
        }
        catch
        {

        }
        



    }



    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            try
            {
                shadowItem = child.GetComponent<Placeable>().SpawnDropItem();

                offsetx = child.GetComponent<Placeable>().offsetx;
                offsety = child.GetComponent<Placeable>().offsety;
                inventoryH.offsetxInv = offsetx;
                inventoryH.offsetyInv = offsety;
            }
            catch { }



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
        try
        {
            offsetx = inventoryH.offsetxInv;
            offsety = inventoryH.offsetyInv;

            if (transform.childCount <= 0)
            {
                inventory.isFull[i] = false;
            }

            if (shadowItem != null)
            {
                if (playerObject.isLeft)
                {
                    Vector2 playerPos = new Vector2(player.position.x - offsetx, player.position.y + offsety);
                    shadowItem.transform.position = playerPos;

                }
                else
                {
                    Vector2 playerPos = new Vector2(player.position.x + offsetx, player.position.y + offsety);
                    shadowItem.transform.position = playerPos;
                }


            }
        }
        catch { }

   



    }



}
