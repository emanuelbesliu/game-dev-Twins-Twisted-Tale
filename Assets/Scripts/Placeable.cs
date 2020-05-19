using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeable : MonoBehaviour
{
    public GameObject itemToDrop;
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

    public void SpawnDropItem()
    {
        Vector2 playerPos = new Vector2(player.position.x + 3, player.position.y);
        Instantiate(itemToDrop, playerPos, Quaternion.identity);
    }
}
