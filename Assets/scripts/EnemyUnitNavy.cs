using UnityEngine;
using System.Drawing;
using System.Collections;

public class EnemyUnitNavy : MonoBehaviour
{
    private move2 _move2Script;
    public GameObject EvilObject, EarthObject;
    private float _g2, _g1;
    private float _e2, _e1;
    public RectTransform EvilObjectTexture, EarthObjectTexture;
    private SpriteRenderer _spriteEvilTexture, _spriteEarthTexture;
    private Point _evilRectSize, _earthRectSize;

    public void Start()
    {
        _spriteEvilTexture = GameObject.Find("EvilObject").GetComponent<SpriteRenderer>();
        _spriteEarthTexture = EarthObject.GetComponent<SpriteRenderer>();
        _evilRectSize = new Point((int)EvilObjectTexture.rect.height, (int)EvilObjectTexture.rect.width);
        _earthRectSize = new Point((int)EarthObjectTexture.rect.height, (int)EarthObjectTexture.rect.width);
        _move2Script = GameObject.Find("EvilObject").GetComponent<move2>();
    }

    static bool block = false;
    Vector3 oldPos = Vector3.zero;

    public void Update()
    {
        _g1 = _move2Script.transform.position.x;
        _g2 = _move2Script.transform.position.y;

        _e1 = EarthObject.transform.position.x;
        _e2 = EarthObject.transform.position.y;

        RectangleF evilSpriteRect = new RectangleF(_g1,
            _g2, _evilRectSize.X, _evilRectSize.Y);
        RectangleF earthSpriteRect = new RectangleF(_e1,
            _e2, _earthRectSize.X, _earthRectSize.Y);

        if (earthSpriteRect.IntersectsWith(evilSpriteRect))
        {
            if (!block)
            {
                StartCoroutine(c_Block());

                var normal = GetNormal(oldPos, transform.position);

                _move2Script.direction = Vector2.Reflect(_move2Script.direction, normal);              
            }

           // _spriteEarthTexture.color = UnityEngine.Color.green;
        }
        else
          //  _spriteEvilTexture.color = UnityEngine.Color.blue;

        oldPos = _move2Script.transform.position;
    }

    IEnumerator c_Block()
    {
        block = true;
        yield return new WaitForSeconds(0.25f);
        block = false;
    }

    Vector2 GetNormal(Vector3 oldPos, Vector3 wallPos)
    {
        Vector3[] objPositions = new Vector3[]
        {
            oldPos + Vector3.up * 0.5f + Vector3.right * 0.5f,
            oldPos + Vector3.up * 0.5f + Vector3.left * 0.5f,
            oldPos + Vector3.down * 0.5f + Vector3.right * 0.5f,
            oldPos + Vector3.down * 0.5f + Vector3.left * 0.5f
        };

        Vector3[] wallPositions = new Vector3[]
        {
            wallPos + Vector3.up * 0.5f + Vector3.right * 0.5f,
            wallPos + Vector3.up * 0.5f + Vector3.left * 0.5f,
            wallPos + Vector3.down * 0.5f + Vector3.right * 0.5f,
            wallPos + Vector3.down * 0.5f + Vector3.left * 0.5f
        };

        int up = 0, down = 0, right = 0, left = 0;

        for (int i = 0; i < 4; ++i)
        {
            if (objPositions[i].y >= wallPositions[0].y && objPositions[i].y >= wallPositions[1].y)
                up++;

            if (objPositions[i].y <= wallPositions[2].y && objPositions[i].y <= wallPositions[3].y)
                down++;

            if (objPositions[i].x >= wallPositions[0].x && objPositions[i].x >= wallPositions[2].x)
                right++;

            if (objPositions[i].x <= wallPositions[1].x && objPositions[i].x <= wallPositions[3].x)
                left++;
        }

        if (up == 4)
            return Vector2.up;

        if (down == 4)
            return Vector2.down;

        if (right == 4)
            return Vector2.right;

        if (left == 4)
            return Vector2.left;

        return Vector2.zero;
    }
}