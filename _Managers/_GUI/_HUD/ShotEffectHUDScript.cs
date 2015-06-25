using UnityEngine;
using System.Collections;

public class ShotEffectHUDScript : MonoBehaviour {
	public Transform Player; 
	public float X;
	public float Y;
	public float Width;
	public float Height;
	public GUIStyle Style = new GUIStyle();

	private float currentShotEffect;
	private Rect rect;
	private string textToDisplay;

	public static ShotEffectHUDScript Instance { 
		get; 
		private set; 
	}

	public void DisplayShotEffect() {

		GUI.Label(rect, textToDisplay, Style);
	}
	
	public void UpdatePosition() {
		rect = new Rect(X, Y, Width, Height);
	}
	
	public void SetShotEffect(float newShotEffect) {
		currentShotEffect = newShotEffect;
		textToDisplay = (100 * currentShotEffect).ToString("F2") + "%";
		Style.normal.textColor = Color.Lerp(Color.black, Color.red, currentShotEffect);
		
	}
	
	private void Awake () {
		Instance = this;
		UpdatePosition();
		textToDisplay = "";
	}
}
