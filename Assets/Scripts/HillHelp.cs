using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillHelp : MonoBehaviour
{

    public int x;
    public int y;
    public int z;

    private int tempX;
    private int tempX1;
    private int tempY;

    private bool trigger = false;
    // Start is called before the first frame update
    void Start()
    {
        x = 16;
        y = -26;
        z = 0;
        tempX = x;
        tempY = y;
        tempX1 = x;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextTile(){
        if(y<=-26){
            if(x>=54){
                if(y <= -30 && x <= 54){
                //trigger = true;
                    tempX1=17;
                    x=tempX1;
                    y=-25;
                    return;
                }
                if(y > -30){
                    tempX++;
                    x = tempX;
                    y--;
                }
            }else{
                x++;
            }
        }else{
            if(x>=54){
                    if(y < -20){
                        tempX1++;
                        x = tempX1;
                        y++;
                    }
                }else{
                    x++;
                }
        }
    }
}
