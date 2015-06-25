using UnityEngine;
using System.Collections;

public class DeadlyGasScript : MonoBehaviour {
	private void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Player") {
			CoreGameStateScript.Instance.CheckpointLevelReset();
			InformationManagerScript.Instance.IncrementNumberOfRespawns();
		}
	}

}
