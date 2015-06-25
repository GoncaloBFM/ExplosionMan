using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TimerHUDScript : MonoBehaviour, ResizebleGUI {

	public int SubTimersNumber;
	public float XRightAligned;
	public float MainY;
	public float SubY;
	public float Width;
	public float MainHeight;
	public float SubHeight;
	public float SpaceBetween;
	public GUIStyle MainStyle = new GUIStyle();
	public GUIStyle SubStyle = new GUIStyle();
	
	private TimerScript timerScript;
	private InformationManagerScript informationManagerScript;
	private Rect mainLabelRect;
	private List<Rect> subLabelRects = new List<Rect>(); 


	public void DisplayMainTimer() {
		GUI.Label(mainLabelRect, timerScript.GetTimeElapsedFromStart().ToString() , MainStyle);
	}

	public void UpdatePosition() {
		mainLabelRect = new Rect(GUIMatrixScript.OriginalWidth - XRightAligned, MainY, Width, MainHeight);
		subLabelRects.Clear();
		for (int p1 = 0; p1 < SubTimersNumber; p1++) {
			subLabelRects.Add(new Rect(GUIMatrixScript.OriginalWidth - XRightAligned, SubY + (SubHeight + SpaceBetween) * p1, Width, SubHeight));
		}
	}

	public void DisplaySubTimers() {
		int nOfCheckpoints = informationManagerScript.GetNumberOfCheckpoints();
		int startingCheckpoint = nOfCheckpoints - SubTimersNumber;

		startingCheckpoint = startingCheckpoint < 0 ? 0 : startingCheckpoint; 

		int p1 = startingCheckpoint;
		int p2 = 0;

		while (p1 < nOfCheckpoints) {
			GUI.Label(subLabelRects[p2], (p1 + 1) + " - " + informationManagerScript.CheckpointTimes[p1].ToString(), SubStyle);
			p1++;
			p2++;
		}
	}

	private void Awake () {
		timerScript = TimerScript.Instance;
		informationManagerScript = InformationManagerScript.Instance;
		UpdatePosition();
	}

}