using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PreGameCountdownScript : MonoBehaviour {

	public float Width;
	public float Height;
	public GUIStyle Style;	

	private float x;
	private float y;
	private Rect rect;
	private float totalWarmUpTime;
	private float currentTime;
	

	public static PreGameCountdownScript Instance {
		get;
		private set;
	}

	public void ShowCountdown(float warmUpTime) {
		totalWarmUpTime = warmUpTime;
		currentTime = Time.time;
		enabled = true;
	}

	public void StopCountdown() {
		enabled = false;
	}

	private void Awake() {
		Instance = this;

		float x = Screen.width/2 - Width/2;
		float y = Screen.height/2 - Height/2;
		rect = new Rect(x, y, Width, Height);
	}

	private void OnGUI() {
		float secondsRemaining = TimerScript.Instance.GetTimeRemaining(currentTime, totalWarmUpTime).seconds + 1;
		if (secondsRemaining <= 0) {
			enabled = false;
		} else {
			GUI.Label(rect, secondsRemaining.ToString(), Style);
		}
	}

}
