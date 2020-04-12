
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    //private FillRects getScore;
    //public float currentScore = 0f;

    [SerializeField] Text ScoreText;
    
    
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = FillRects.counter.ToString("0");
        //Debug.Log(ScoreText.text);
    }
}
