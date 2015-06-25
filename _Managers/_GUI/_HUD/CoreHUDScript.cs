using UnityEngine;
using System.Collections;

public class CoreHUDScript : MonoBehaviour {
	
	private ReloadHUDScript reloadHUDScript;
	private VelocityHUDScript velocityHUDScript;
	private ShotEffectHUDScript shotEffectHUDScript;
	private TimerHUDScript timerHUDScript;
	private SkiEnabledHUDScript skiEnabledHUDScript;
	private CrosshairHUDScript crosshairHUDScript;
	

	public static CoreHUDScript Instance {
		get;
		private set;
	}

	private void Awake () {
		Instance = this;

		reloadHUDScript = GetComponent<ReloadHUDScript>();
		velocityHUDScript = GetComponent<VelocityHUDScript>();
		shotEffectHUDScript = GetComponent<ShotEffectHUDScript>();
		timerHUDScript = GetComponent<TimerHUDScript>();
		crosshairHUDScript = GetComponent<CrosshairHUDScript>();
		skiEnabledHUDScript = GetComponent<SkiEnabledHUDScript>();
	}

	private void OnGUI () {
		GUIMatrixScript.Instance.Update();

		reloadHUDScript.DisplayAmmoBar();
		velocityHUDScript.DisplaySpeedometer();
		shotEffectHUDScript.DisplayShotEffect();
		timerHUDScript.DisplayMainTimer();
		timerHUDScript.DisplaySubTimers();
		crosshairHUDScript.DisplayCrosshair();
		skiEnabledHUDScript.DisplaySkiIcon();
	}


}