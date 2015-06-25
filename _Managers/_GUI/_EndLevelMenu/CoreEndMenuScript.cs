using UnityEngine;
using System.Collections;

public class CoreEndMenuScript : MonoBehaviour {

	public Color WinningTransitionColor;
	public int WinningTransitionDepth;
	public float WinningTransitionTime;
	
	private Rect rect;

	private TimerEndMenuScript timerEndMenuScript;

	public static CoreEndMenuScript Instance{
		get;
		private set;
	}
	
	public void GetGameInformation() {
		timerEndMenuScript.SetTimerInformation();
	}

	public void PlayWinningTransition(){
		FadeScreenScript.Instance.FadeInBackground(WinningTransitionColor, 
		                                           WinningTransitionDepth, 
		                                           WinningTransitionTime,  
		                                           false);
		StartCoroutine(DelayedEnable(true, WinningTransitionTime));
	}

	public IEnumerator DelayedEnable(bool value, float delay) {
		yield return new WaitForSeconds(delay);
		enabled = value;
		Time.timeScale = 0;
		CursorManagerScript.Instance.CursorEnabled = true;
	}


	private void Awake() {
		Instance = this;
		enabled = false;
		timerEndMenuScript = GetComponent<TimerEndMenuScript>();
	}

	private void OnGUI() {
		timerEndMenuScript.DisplayTimer();
	}
}
