
using UnityEngine;
using UnityEngine.UI;

public class CapturedTeretory : MonoBehaviour
{
    private FillRects getScore;
    public float currentTretoryCaptured = 0f;
    double percent;

    [SerializeField] Text FieldCaptured;

    void Update()
    {

        currentTretoryCaptured = FillRects.counter;
        percent = currentTretoryCaptured/(574 / 100);
        FieldCaptured.text = percent.ToString("0");
        //Debug.Log(FieldCaptured.text);


        if (percent == 75) 
        {
            
        }
    }
}
