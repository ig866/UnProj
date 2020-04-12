using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControllScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerClickHandler
{
        //public Vector2 position = new Vector2(1, -1);
    void Start()
    {
        quad.transform.position = new Vector2(0f, 9f);
        spriteQuad = quad.GetComponent<SpriteRenderer>();
    }

    public GameObject quad;
    SpriteRenderer spriteQuad;
    public float dirX, dirY;
    //static public Vector2 StartPosition = new Vector2(0, 9);
    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 1)
            OnSingleClick();
        else if (clickCount == 2)
            OnDoubleClick();
        else if (clickCount > 2)
            OnMultiClick();
    }

    void OnSingleClick()
    {
        //Debug.Log("Single Clicked");
    }

    void OnDoubleClick()
    {
        Debug.Log("Double Clicked");
        dirX = 0;
        dirY = 0;
        FillRects.PassEndsIndenti = false;// индентификатор окончания пути и начала обработки стака для заполнения 
    }

    void OnMultiClick()
    {
        Debug.Log("MultiClick Clicked");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if ((Mathf.Abs(eventData.delta.x)) > (Mathf.Abs(eventData.delta.y)))
        {
            if (eventData.delta.x > 0)
            {
                // quad.transform.position = new Vector2(quad.transform.position.x + 0.50f, quad.transform.position.y);
                // return quad.transform.position;
                spriteQuad.color = Color.blue;
                dirX = +0.5f;
                dirY = 0;

            }
            else
            {
                // quad.transform.position = new Vector2(quad.transform.position.x - 0.50f, transform.position.y);
                spriteQuad.color = Color.red;
                //  return quad.transform.position;
                dirX = -0.5f;
                dirY = 0;
            }
        }
        else if ((Mathf.Abs(eventData.delta.x)) < (Mathf.Abs(eventData.delta.y)))
        {
            if (eventData.delta.y > 0)
            {
                //quad.transform.position = new Vector2(transform.position.x, quad.transform.position.y + 0.5f);
                spriteQuad.color = Color.yellow;
                //return quad.transform.position;
                dirY = +0.5f;
                dirX = 0;
            }
            else
            {
                //quad.transform.position = new Vector2(transform.position.x, quad.transform.position.y - 0.5f);
                spriteQuad.color = Color.green;
                //  return quad.transform.position;
                dirY = -0.5f;
                dirX = 0;
            }
        }
        else if ((Mathf.Abs(eventData.delta.x)) == (Mathf.Abs(eventData.delta.y)))
        {
            Debug.Log("Single Clicked");

        }


    }


    void Update()
    {
        //  dirX = 0;
        //  dirY = 0;
        // transform.Translate(new Vector2(1, 0) * Time.deltaTime);
        // quad.transform.position = (new Vector2(quad.transform.position.x+dirX, quad.transform.position.y+dirY)*Time.deltaTime);
        //quad.transform.position = new Vector2(quad.transform.position.x + dirX, quad.transform.position.y + dirY) ;
        quad.transform.position = Vector2.Lerp(quad.transform.position, new Vector2(quad.transform.position.x + dirX, quad.transform.position.y + dirY), Time.deltaTime);

        //if (quad.transform.position.x == 22)
        //{
        //   quad.transform.position = Vector2(0,0);
        //    dirX = -0.5f;
        //    //dirY = 0;
        //    
        //}
    }

    public void OnDrag(PointerEventData eventData)
    {
    }


}
