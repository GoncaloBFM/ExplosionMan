using UnityEngine;
using System.Collections;

public class OptionsPauseMenuScript : MonoBehaviour {

	public float TitleY;
	public float TitleWidth;

	public float BackButtonY;
	public float BackButtonWidth;
	public float BackButtonHeight;

	public float BackgroundY;
	public float BackgroundWidth;
	public float BackgroundHeight;

	public GUIContent TitleContent = new GUIContent();
	public GUIContent BackButtonContent = new GUIContent();
	public GUIStyle TitleStyle = new GUIStyle();

	private CorePauseMenuScript corePauseMenuScript;
	private BackgroundPauseMenuScript backgroundPauseMenuScript;
	private FovSliderPauseMenuScript fovSliderPauseMenuScript;
	private VolumeSliderPauseMenuScript [] volumeSliderPauseMenuScripts;
	
	private float totalHeight;
	private Rect titleRect;
	private Rect backButtonRect;
	private Rect backgroundRect;
	
	
	public void DisplayOptions () {
		backgroundPauseMenuScript.DisplayBackground(backgroundRect);
		GUI.Label(titleRect, TitleContent, TitleStyle);
		fovSliderPauseMenuScript.DisplayFovSlider();
		foreach(VolumeSliderPauseMenuScript script in volumeSliderPauseMenuScripts) {
			script.DisplayVolumeSlider();
		}
		if (GUI.Button(backButtonRect, BackButtonContent)) {
			corePauseMenuScript.CurrentPage = CorePauseMenuScript.Page.Front;
		}
	}
	
	private void Awake() {
		corePauseMenuScript = GetComponent<CorePauseMenuScript>();
		backgroundPauseMenuScript = GetComponent<BackgroundPauseMenuScript>();
		fovSliderPauseMenuScript = GetComponent<FovSliderPauseMenuScript>();
		volumeSliderPauseMenuScripts = GetComponents<VolumeSliderPauseMenuScript>();

		float titleX = GUIMatrixScript.OriginalWidth/2f - TitleWidth/2f;
		float backButtonX = GUIMatrixScript.OriginalWidth/2f - BackButtonWidth/2f;
		float backgroundX = GUIMatrixScript.OriginalWidth/2f - BackgroundWidth/2f;

		backButtonRect = new Rect(backButtonX, BackButtonY, BackButtonWidth, BackButtonHeight);
		backgroundRect = new Rect(backgroundX, BackgroundY, BackgroundWidth, BackgroundHeight);
		titleRect = new Rect(titleX, TitleY, TitleWidth, 0);
	}
}