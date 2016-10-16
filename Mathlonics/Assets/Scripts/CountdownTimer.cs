using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {

	public Text timeRemaining;
	public float time = 80;
	float minutes = 0;
	float seconds = 0;
	bool timeOn = true;

	// Use this for initialization
	void Start () {
	
		minutes = time / 60;
		seconds = time % 60;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(timeOn && time > 0)
		{
			time -= Time.deltaTime;
			//newMinute -= Time.deltaTime;

			minutes = Mathf.Floor( time / 60);
			seconds = time % 60;

			timeRemaining.text = string.Format ("{0:00}:{1:00}", minutes, seconds);
		}
	}
}
