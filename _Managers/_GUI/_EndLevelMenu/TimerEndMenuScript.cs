using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimerEndMenuScript : MonoBehaviour {
	
	public float X;
	public float MainY;
	public float SubY;
	public float Width;
	public float MainHeight;
	public float SubHeight;
	public float SpaceBetween;
	public GUIStyle MainStyle = new GUIStyle();
	public GUIStyle SubStyle = new GUIStyle();

	private string mainTime;
	private List<string> subTimes = new List<string>();
	private Rect mainLabelRect;
	private List<Rect> subLabelRects = new List<Rect>(); 


	public void DisplayTimer() {		
		GUI.Label(mainLabelRect, "Total Time:" + mainTime , MainStyle);
		for(int p1 = 0; p1 < subTimes.Count; p1++){
			GUI.Label(subLabelRects[p1], (p1 + 1) + " - " + subTimes[p1], SubStyle);
		}
	}
	
	public void SetTimerInformation() {

		mainTime = InformationManagerScript.Instance.TotalTime.ToString();

		foreach(TimeElapsed time in InformationManagerScript.Instance.CheckpointTimes) {
			subTimes.Add(time.ToString());
		}

		mainLabelRect = new Rect(Screen.width/2f - X/2f, MainY, Width, MainHeight);

		for (int p1 = 0; p1 < subTimes.Count; p1++) {
			subLabelRects.Add(new Rect(Screen.width/2f - X/2f, SubY + (SubHeight + SpaceBetween) * p1, Width, SubHeight));
		}
	}
}
