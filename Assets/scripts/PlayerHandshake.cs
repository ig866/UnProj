
using UnityEngine;
using System.Drawing;

public class PlayerHandshake : MonoBehaviour
{
    private bool StillLive = true;
    public GameObject GoodObject, EvilObject, EvilObjectE;
    private float _g2, _g1, _e2, _e1, _t1, _t2;
    //private float _e2, _e1;
    public RectTransform GoodObjectTexture, EvilObjectTexture, EvilObjectTextureEarth;
    private SpriteRenderer _spriteGoodTexture, _spriteEvilTexture, _spriteEvilTextureEarth;
    private Point _goodRectSize, _evilRectSize, _evilRectSizeEarth;
    public static int counter = 0;

    public void Start()
    {

        _spriteGoodTexture = GoodObject.GetComponent<SpriteRenderer>();
        _spriteEvilTexture = EvilObject.GetComponent<SpriteRenderer>();
        _spriteEvilTextureEarth = EvilObjectE.GetComponent<SpriteRenderer>();
        _goodRectSize = new Point((int)GoodObjectTexture.rect.height, (int)GoodObjectTexture.rect.width);
        _evilRectSize = new Point((int)EvilObjectTexture.rect.height, (int)EvilObjectTexture.rect.width);
        _evilRectSizeEarth = new Point((int)EvilObjectTextureEarth.rect.height, (int)EvilObjectTextureEarth.rect.width);
    }
    void Update()

    {

        _g1 = (float)GoodObject.transform.position.x;
        _g2 = (float)GoodObject.transform.position.y;

        _e1 = (float)EvilObject.transform.position.x;
        _e2 = (float)EvilObject.transform.position.y;

        _t1 = (float)EvilObjectE.transform.position.x;
        _t2 = (float)EvilObjectE.transform.position.y;

        RectangleF goodSpriteRect = new RectangleF(_g1,
            _g2, (float)_goodRectSize.X, (float)_goodRectSize.Y);
        RectangleF evilSpriteRect = new RectangleF(_e1,
            _e2, (float)_evilRectSize.X, (float)_evilRectSize.Y);
        RectangleF evilSpriteRectE = new RectangleF(_t1,
            _t2, (float)_evilRectSizeEarth.X, (float)_evilRectSizeEarth.Y);



        if (StillLive)
        {
            if ((goodSpriteRect.IntersectsWith(evilSpriteRectE)) || (goodSpriteRect.IntersectsWith(evilSpriteRect)))

            {
                Debug.Log("koll");
                _spriteEvilTextureEarth.color = UnityEngine.Color.red;
                _spriteGoodTexture.color = UnityEngine.Color.red;
                _spriteEvilTexture.color = UnityEngine.Color.red;
                LoseLive();

            }
            else
            {
                _spriteEvilTextureEarth.color = UnityEngine.Color.white;
                _spriteGoodTexture.color = UnityEngine.Color.white;
                _spriteEvilTexture.color = UnityEngine.Color.white;

            }
        }



    }
    void LoseLive()
    {
        StillLive = false;
        Debug.Log("-1L");
        PlayerLives.Live--;
        // StillLive = true;
    }


}