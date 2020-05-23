using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CleanArea : MonoBehaviour
{
    
    
    public GameObject tilemapGameObject;

    Tilemap tilemap;
    // Start is called before the first frame update
    void Start()
    {
         
        if (tilemapGameObject != null)
        {
            tilemap = tilemapGameObject.GetComponent<Tilemap>();
        }
    }
    /**
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hill"))
        {
            other.gameObject.SetActive(false);

        }
    }
    **/
    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 hitPosition = Vector3.zero;
        foreach (ContactPoint2D hit in collision.contacts)
        {
            Debug.Log(hit.point);
            hitPosition.x = hit.point.x - 0.1f;
            hitPosition.y = hit.point.y - 0.1f;
            tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
        }
        
    }



    // Update is called once per frame
    void Update()
    {

    }
}
