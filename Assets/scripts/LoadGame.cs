using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadGame : MonoBehaviour {
    Random RandX = new Random();
    Random RandY = new Random();
    public GameObject Box;
    public GameObject BoxTerrian;
   // private int RandEvilSpavnX = RandX.Next(-20,20);

    static int collB = 41, rowB = 14 ;
    static int collTop = 45, rowTop = 2;
    static int collBot = 45, rowBot = 2;
    static int collRight = 2, rowRight = 14;
    static int collLeft= 2, rowLeft = 14;
    static int BorderCollLeft = 1, BorderRowLeft = 18;
    static int BorderCollTop = 47, BorderRowTop = 1;
    static int BorderCollBottom = 47, BorderRowBottom = 1;
    static int BorderCollRight = 1, BorderRowRight = 18;




    void CrateGamePole() 
    {
        float Dx = 1f, Dy = 1f;

        Vector2 MyStanceB = new Vector2(-20, -5);//21/7
        Vector2 MyStanceTop = new Vector2(-22, 9);//21/7
        Vector2 MyStanceBot = new Vector2(-22, -7);//21/7
        Vector2 MyStanceRight = new Vector2(21, -5);//21/7
        Vector2 MyStanceLeft = new Vector2(-22, -5);//21/7
        Vector2 MyStanceTop1 = new Vector2(-23, 11);//21/7
        Vector2 MyStanceBot1 = new Vector2(-23, -8);//21/7
        Vector2 MyStanceRight1 = new Vector2(23, -7);//21/7
        Vector2 MyStanceLeft1 = new Vector2(-23, -7);//21/7



        for (int YY = 0; YY < rowB; YY++)
        {
            for (int XX = 0; XX < collB; XX++)
            {
                Instantiate(Box, MyStanceB, Quaternion.identity);
                MyStanceB.x += Dx;
            }

            MyStanceB.x = -20f;
            MyStanceB.y += Dy;
        }
        for (int YY = 0; YY < BorderRowBottom; YY++)
        {
            for (int XX = 0; XX < BorderCollBottom; XX++)
            {
                Instantiate(Box, MyStanceBot1, Quaternion.identity);
                MyStanceBot1.x += Dx;
               // Box.SetActive(false);
            }
            MyStanceBot1.x = -23f;
            MyStanceBot1.y += Dy;
        }
        for (int YY = 0; YY < BorderRowTop; YY++)
        {
            for (int XX = 0; XX < BorderCollTop; XX++)
            {
                Instantiate(Box, MyStanceTop1, Quaternion.identity);
                MyStanceTop1.x += Dx;
                //Box.SetActive(false);
            }
            MyStanceTop1.x = -23f;
            MyStanceTop1.y += Dy;
        }
        for (int YY = 0; YY < BorderRowRight; YY++)
        {
            for (int XX = 0; XX < BorderCollRight; XX++)
            {
                Instantiate(Box, MyStanceRight1, Quaternion.identity);
                MyStanceRight1.x += Dx;
               //Box.SetActive(false);
            }
            MyStanceRight1.x = 23f;
            MyStanceRight1.y += Dy;
        }
        for (int YY = 0; YY < BorderRowLeft; YY++)
        {
            for (int XX = 0; XX < BorderCollLeft; XX++)
            {
                Instantiate(Box, MyStanceLeft1, Quaternion.identity);
                MyStanceLeft1.x += Dx;
                //Box.SetActive(false);
            }
            MyStanceLeft1.x = -23f;
            MyStanceLeft1.y += Dy;
        }
        ////////////////////////////////////////////////
        for (int YY = 0; YY < rowTop; YY++)
        {
            for (int XX = 0; XX < collTop; XX++)
            {
                Instantiate(BoxTerrian, MyStanceTop, Quaternion.identity);
                MyStanceTop.x += Dx;
            }
            MyStanceTop.x = -22f;
            MyStanceTop.y += Dy;
        }

        for (int YY = 0; YY < rowBot; YY++)
        {
            for (int XX = 0; XX < collBot; XX++)
            {
                Instantiate(BoxTerrian, MyStanceBot, Quaternion.identity);
                MyStanceBot.x += Dx;
            }
            MyStanceBot.x = -22f;
            MyStanceBot.y += Dy;

        }
        for (int YY = 0; YY < rowRight; YY++)
        {
            for (int XX = 0; XX < collRight; XX++)
            {
                Instantiate(BoxTerrian, MyStanceRight, Quaternion.identity);
                MyStanceRight.x += Dx;
            }
            MyStanceRight.x = 21f;
            MyStanceRight.y += Dy;

        }
        for (int YY = 0; YY < rowLeft; YY++)
        {
            for (int XX = 0; XX < collLeft; XX++)
            {
                Instantiate(BoxTerrian, MyStanceLeft, Quaternion.identity);
                MyStanceLeft.x += Dx;
            }
            MyStanceLeft.x = -22f;
            MyStanceLeft.y += Dy;

        }

    }
          
 


// Start is called before the first frame update
void Start()
    {
        CrateGamePole();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
