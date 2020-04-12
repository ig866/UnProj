using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool MinusLife = false;
    public static int Live = 1;
    [SerializeField] Text LiveText;
    bool Sceneloader = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LiveText.text = Live.ToString();
        //Debug.Log(MinusLife);

        for (int i = 0; i < 1; i++)
        {
            if (Live == 0)
            {
               // SceneManager.LoadScene(SceneManager.GetActiveScene().name);// возобновление после потери жизни
                Live = +1;
                FillRects.counter = 0 ;
               // Time.timeScale = 0;
               // PauseGame.paused = true;
               // PauseGame.PanelPause.SetActive(true);

            }
            
        }

    }

     
}
