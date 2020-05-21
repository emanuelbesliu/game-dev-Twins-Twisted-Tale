using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntScript : MonoBehaviour
{
    public float Speed;

    public bool up;
    public bool down;
    public bool left;
    public bool right;

    private bool hasTurned = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(up){
            this.transform.position += Vector3.up * Time.deltaTime * Speed ;
        }

        if(down){
            this.transform.position += Vector3.down * Time.deltaTime * Speed ;
        }

        if(left){
            this.transform.position += Vector3.left * Time.deltaTime * Speed ;

        }

        if(right){
            this.transform.position += Vector3.right * Time.deltaTime * Speed ;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AntUp"))
        {
            up = true;
        }else if (collision.gameObject.CompareTag("AntDown")){
            down = true;
        }else if (collision.gameObject.CompareTag("AntRight"))
        {
            right = true;
        }else if (collision.gameObject.CompareTag("AntLeft"))
        {
            left = true;
        }else if (collision.gameObject.CompareTag("AntOff")){
            collision.gameObject.SetActive(false);
            up = false;
            down = false;
            right = false;
            left = false;
        }else if(collision.gameObject.CompareTag("AntDownOff")){
            up = false;
            down = true;
            right = false;
            left = false;
        }else if(collision.gameObject.CompareTag("AntRightOff")){
            if(hasTurned){
                this.transform.Rotate(new Vector3(0,180,0));
                hasTurned = false;
            }
            up = false;
            down = false;
            right = true;
            left = false;
        }else if(collision.gameObject.CompareTag("AntUpOff")){
            up = true;
            down = false;
            right = false;
            left = false;
        }else if(collision.gameObject.CompareTag("AntLeftOff")){
            if(!hasTurned){
                this.transform.Rotate(new Vector3(0,180,0));
                hasTurned = true;
            }
            up = false;
            down = false;
            right = false;
            left = true;
        }
    }
}
