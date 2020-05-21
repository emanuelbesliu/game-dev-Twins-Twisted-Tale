using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugScript : MonoBehaviour
{
    public float Speed;
    public int direction;
    // Start is called before the first frame update
    void Start()
    {
       // direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == 1){
            this.transform.position += Vector3.left * Time.deltaTime * Speed ;
        }else{
            this.transform.position += Vector3.right * Time.deltaTime * Speed ;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyStop"))
        {
            //Debug.Log("Hit");
            this.transform.Rotate(new Vector3(0,180,0));
            if(direction == 1){
                direction = -1;
            }else{
                direction = 1;
            }
        }

    }
}
