using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CleanArea : MonoBehaviour
{
    
    
    public GameObject tilemapGameObject;
    Vector3Int pPos;
    Vector3Int saveVector;
    public int shovelRadius;

    public Tilemap tilemap;
    void Start()
    {
        tilemap = this.gameObject.GetComponent<Tilemap>();


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Detecting the Grid Position of Player
        if (collision.gameObject.name == "ShovelClean(Clone)")
        {
            // Destroy a square around the contanct area.

            pPos = tilemap.WorldToCell(collision.rigidbody.position);
            pPos.x += 3;
            pPos.y -= 2;
            Debug.Log("pPos:" + pPos);
            tilemap.SetTile(pPos, null);

            for (int i = pPos.x - shovelRadius; i < pPos.x; i++)
            {
                for (int j = pPos.y - shovelRadius; j < pPos.y; j++)
                {
                    if ((i - pPos.x) * (i - pPos.x) + (j - pPos.y) * (j - pPos.y) <= shovelRadius * shovelRadius)
                    {
                        int xSym = pPos.x - (i - pPos.x);
                        int ySym = pPos.y - (j - pPos.y);
                        saveVector.x = xSym;
                        saveVector.y = ySym;

                        tilemap.SetTile(saveVector, null);

                        saveVector.x = i;
                        saveVector.y = ySym;

                        tilemap.SetTile(saveVector, null);

                        saveVector.x = xSym;
                        saveVector.y = j;

                        tilemap.SetTile(saveVector, null);
                        saveVector.x = i;
                        saveVector.y = j;

                        tilemap.SetTile(saveVector, null);



                    }



                }



            }

        }
    }
}
