using UnityEngine;
using System.Collections;

public class FinishLineScript : MonoBehaviour {
		
	private void OnTriggerEnter () {
		CoreGameStateScript.Instance.CurrentGameState = CoreGameStateScript.GameState.LevelFinished;
		InformationManagerScript.Instance.AddCheckpointTime();
	}
}
