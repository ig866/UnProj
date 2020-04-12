using UnityEngine;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;

public class FillRects : MonoBehaviour
{
    public GameObject GoodObject, EvilObject, EarthObject, PathObject;
    private float _g2, _g1;
    private float _e2, _e1;
    public RectTransform GoodObjectTexture, EvilObjectTexture;
    private SpriteRenderer _spriteGoodTexture, _spriteEvilTexture;
    private Point _goodRectSize, _evilRectSize;//размеры ы
    public static int counter = 0;//счетчик 
    public Vector3[] TestCoord;
    public Vector3[] TestCoord1;
    static public GameObject[] ObjectsAll;// массив всех объектов
    static public GameObject[] EarthTagObjectsAll;// массив земли с тэгами
    static public Stack<Vector3> mySosedStack = new Stack<Vector3>();
    static public Stack<GameObject> myStackPath = new Stack<GameObject>();/// Стак пути
    //static public Stack<GameObject> myStackP = new Stack<GameObject>();/// Стак пути запасной
    static public Stack<GameObject> myRecursiveStack = new Stack<GameObject>();/// Стак пути
    static public bool PassEndsIndenti = true;// инд конца пути
    int aaa = 0;
    public void Start()
    {
        ObjectsAll =  GameObject.FindGameObjectsWithTag("tagBox");
        EarthTagObjectsAll = GameObject.FindGameObjectsWithTag("tagEarth");
        _spriteGoodTexture = GoodObject.GetComponent<SpriteRenderer>();
        _spriteEvilTexture = EvilObject.GetComponent<SpriteRenderer>();
        _goodRectSize = new Point((int)GoodObjectTexture.rect.height, (int)GoodObjectTexture.rect.width);
        _evilRectSize = new Point((int)EvilObjectTexture.rect.height, (int)EvilObjectTexture.rect.width);
        
    }
    public void Update()

    {

        _g1 = (float)GoodObject.transform.position.x;
        _g2 = (float)GoodObject.transform.position.y;

        _e1 = (float)EvilObject.transform.position.x;
        _e2 = (float)EvilObject.transform.position.y;

        RectangleF goodSpriteRect = new RectangleF(_g1,
            _g2, (float)_goodRectSize.X, (float)_goodRectSize.Y);
        RectangleF evilSpriteRect = new RectangleF(_e1,
            _e2, (float)_evilRectSize.X, (float)_evilRectSize.Y);

        if (goodSpriteRect.IntersectsWith(evilSpriteRect))// проверка на колизию
        {
            if (EvilObject.tag != "ColisionBlock")// проверка  не заблокирован ли тайтл
            {
                EvilObject.tag = "ColisionBlock";// блокировка проверенного тайтла

                myStackPath.Push(EvilObject);  //Debug.Log(PassEndsIndenti);

                GenCoordsMet(this.gameObject, TestCoord, mySosedStack);

                Instantiate(PathObject, EvilObject.transform.position, Quaternion.identity);//Замена объекта путь на объект земля

                counter += 1;// счётчик количества замен
            }
            // Debug.Log(PassEndsIndenti);

            if (PassEndsIndenti == false)// при остановке  запускаю скрипт замены всех тайтлов пути на тайтлы  земли
            {
                Search(ObjectsAll, myStackPath, TestCoord1, mySosedStack, TestCoord, myRecursiveStack);
            }
        }

    }


    void Search( GameObject[] EarthObjectsAll, Stack<GameObject> myStack, Vector3[] TestCoord1, Stack<Vector3> mySosedStack, Vector3[] TestCoord, Stack<GameObject> myRecursiveStack)
    {

        foreach (GameObject O in myStack)// перебор объектов стака пути
        {
           Instantiate(EarthObject, O.transform.position, Quaternion.identity);//замена всех объектов пути на землю
        }

        FillPath(EarthObjectsAll, mySosedStack);

        mySosedStack = new Stack<Vector3>();

        foreach (GameObject D in myRecursiveStack)
        {

           GenCoordsMet(D, TestCoord, mySosedStack);

        }
       // while EndOfFill !
        FillPath(EarthObjectsAll,mySosedStack);

        PassEndsIndenti = true;// возвращаю индикатор окончания пути в нормальное состояние
    }

     void FillPath(GameObject[] EarthObjectsAll, Stack<Vector3> mySosedStack)
    {
        foreach (GameObject D in EarthObjectsAll)// перебераем все объекты
        {
            Vector3 ObjectPosition = D.transform.position;// получаем координаты объекта

            foreach (Vector3 V in mySosedStack)// перебераем объекты соседей
            {
                if (ObjectPosition.Equals(V))//сравниваем позиции 
                {

                    Instantiate(EarthObject, ObjectPosition, Quaternion.identity);// заполнение пути

                    myRecursiveStack.Push(D);// координаты соседей для  заливки 

                    ////////////////////////////////////
                    //foreach (GameObject T in EarthTagObjectsAll)
                    //{
                    //    Vector3 EarthTagCoords = T.transform.position;
                    //    foreach (Vector3 I in mySosedStack)

                    //    if (EarthTagCoords.Equals(I))
                    //    {
                    //            break;
                    //           // Debug.Log("break");
                    //     }
                    //}
                    Debug.Log("итерация поиска");
                    Debug.Log(V);
                    ///////////////////
                }
            }
        }
       // myRecursiveStack = null;
    }
    void GenCoordsMet(GameObject thatObgect, Vector3[] TestCoord, Stack<Vector3> mySosedStack)
    {
        Vector3 Pozition = thatObgect.transform.position;// координаты  объекта земли 
        TestCoord = GenCoordTest(Pozition);// наполнение массива координатами соседей 
        foreach (Vector3 T in TestCoord) Debug.Log(T + "TestCoord");// Координаты соседей
        

        foreach (Vector3 G in TestCoord)
        {
            mySosedStack.Push(G); // создает следуюший шаг соседей
        }
    }

     Vector3[] GenCoordTest(Vector3 T)
    {
        Vector3[] S = new Vector3[1];/*Объявим массив из 4 точек*/


        S[0] = T; S[0].x++; //правая точка

        //S[1] = T; S[1].x--; //левая точка

        // S[2] = T; S[2].y++; //верхняя точка

        //S[3] = T; S[3].y--; //нижняя точка 

        return S;
    }

   

}