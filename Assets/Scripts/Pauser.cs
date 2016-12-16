using UnityEngine;
using System.Collections;

public class Pauser : MonoBehaviour {
	private bool paused = false;
	

	void Update () {
		// Listen for P to be pressed
		if(Input.GetKeyUp(KeyCode.P))
		{
			paused = !paused;
		}
		// Stop the time if active
		if(paused)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
	}
}
