using UnityEngine;
using System.Collections;

public class PauseGameScript : MonoBehaviour {

	public Transform Player;	

	private bool _paused;
	private CorePlayerScript corePlayerScript;
	private float currentTimeScale;


	public bool Paused {
		get {
			return _paused;
		}
		set {
			if (_paused != value) {
				_paused = value;
				corePlayerScript.InputScriptsEnabled = !value;
				corePlayerScript.AnimationScriptsEnabled = !value;
				AudioListener.pause = value;
				if (_paused) {
					currentTimeScale = Time.timeScale;
					Time.timeScale = 0;
				} else {
					Time.timeScale = currentTimeScale;
				}
			}
		}
	}
		
	public static PauseGameScript Instance { 
		get; 
		private set; 
	}

	private void Awake () {
		Instance = this;
		corePlayerScript = Player.GetComponent<CorePlayerScript>();
	}


}
