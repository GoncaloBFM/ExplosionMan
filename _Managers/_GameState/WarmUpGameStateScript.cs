using UnityEngine;
using System.Collections;

public class WarmUpGameStateScript : MonoBehaviour {

	private const int LEFT_MOUSE_BUTTON = 0;


	public float StartingWarmUpTime;

	private CoreGameStateScript coreGameStateScript;

	
	public float WarmUpTime {
		get;
		private set;
	}

	public void StartWarmUpTimer() {
		enabled = true;
		StartCoroutine(EndWarmUpCoroutine());
	}
	
	private void Update() {
		if (Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON) && (coreGameStateScript.CurrentGameState == CoreGameStateScript.GameState.WarmUp)) {
			StopAllCoroutines();
			EndWarmUp();
			PreGameCountdownScript.Instance.StopCountdown();
		}
	}
	
	private void EndWarmUp() {
		TimerScript.Instance.ResetTimer();
		coreGameStateScript.CurrentGameState = CoreGameStateScript.GameState.MidLevel;
		enabled = false;
	}

	private IEnumerator EndWarmUpCoroutine() {
		yield return new WaitForSeconds(WarmUpTime);
		EndWarmUp();
	}
	
	private void Awake() {		
		WarmUpTime = StartingWarmUpTime;
		enabled = false;

		coreGameStateScript = GetComponent<CoreGameStateScript>();
	}
}
