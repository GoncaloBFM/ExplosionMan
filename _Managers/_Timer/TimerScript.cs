using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimerScript : MonoBehaviour {
	
	private float startTime;
	private float timeMarker;


	public static TimerScript Instance{
		get;
		private set;
	}

	public TimeElapsed GetTimeElapsedFromStart() {
		return GetTimeElapsed(startTime);
	}
	
	public TimeElapsed GetTimeRemaining(float from, float total) {
		float timeSpan = (from - Time.time) + total;
		
		return ConvertToTimeStrut(timeSpan);
	}

	public TimeElapsed GetTimeElapsedFromMarker() {
		return GetTimeElapsed(timeMarker);
	}

	public void ResetTimer() {
		startTime = Time.time;
		SetTimeMarker();
	}

	public void SetTimeMarker() {
		timeMarker = Time.time;
	}

	private void Awake () {
		Instance = this;
	}

	private TimeElapsed GetTimeElapsed(float from) {
		float timeSpan = Time.time - from;
		return ConvertToTimeStrut(timeSpan);
	}

	private TimeElapsed ConvertToTimeStrut(float timeSpan) {
		int hundredths = (int)Mathf.Floor((timeSpan - Mathf.Floor(timeSpan)) * 100); 
		int seconds = (int)Mathf.Floor(timeSpan) % 60;
		int minutes = (int)Mathf.Floor(timeSpan / 60);

		return new TimeElapsed(hundredths, seconds, minutes);
	}
}
