using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour
{
	public static bool paused = false;
	public  GameObject PanelPause;
	//public GameObject ButtonPause;
	// Update is called once per frame
	public void PGame()
	{

			if (!paused)
			{
				Time.timeScale = 0;
				paused = true;
				PanelPause.SetActive(true);
			}
			else
			{
				Time.timeScale = 1;
				paused = false;
				PanelPause.SetActive(false);
			}
		
	}
}