using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeable : MonoBehaviour
{
    public GameObject itemToDrop;
    public Quaternion toPlaceRotation = Quaternion.Euler(0, 0, 90);
    public float offsetx = 3;
    public float offsety = - 2.5f;
    



    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }


    public GameObject SpawnDropItem()
    {
        Vector2 playerPos = new Vector2(player.position.x + offsetx, player.position.y +offsety);
        return Instantiate(itemToDrop, playerPos, toPlaceRotation ) as GameObject;
    }
}
