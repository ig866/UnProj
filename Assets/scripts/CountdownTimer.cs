using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    private bool playTimer = true;
    float currentTime = 0f;
    float startingTime = 10f;

    [SerializeField] Text countdownText;
   // [SerializeField] Text youloseText;

    void Start()
    {
        currentTime = startingTime;
    }
    void Update()
    {
        if (playTimer)
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                currentTime = 0;
                TimerStop();
            }
        }
 
    }

    void TimerStop()
    {
        playTimer = false;
        PlayerLives.Live--;
    }


}
