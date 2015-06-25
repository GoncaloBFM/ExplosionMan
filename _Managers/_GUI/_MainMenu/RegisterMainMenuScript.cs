using UnityEngine;
using System.Collections;

public class RegisterMainMenuScript : MonoBehaviour {

	public float ButtonsX;
	public float ButtonsY;
	public float ButtonWidth; 
	public float ButtonHeight;
	public float SpaceBetween;

	public GUIContent Content1 = new GUIContent();
	public GUIContent Content2 = new GUIContent();
	
	public GUIStyle ButtonStyle = new GUIStyle();
	
	
	private CoreMainMenuScript coreMainMenuScript;
	private float totalButtonHeight;
	private Rect rect1;
	private Rect rect2;
	
	public void DysplayRegister() {
	}

	public void DisplayFront () {	
		//TODO: ButtonStyle
		if (GUI.Button(rect1, Content1, ButtonStyle)) {
			coreMainMenuScript.CurrentPage = CoreMainMenuScript.Page.Front;
		} else if (GUI.Button(rect2, Content2, ButtonStyle)) {
			//coreMainMenuScript.CurrentPage = CoreMainMenuScript.Page.Options;
		}
	}
	
	private void Awake() {
		coreMainMenuScript = GetComponent<CoreMainMenuScript>();
		
		float y1 = ButtonsY + ButtonHeight + SpaceBetween;
		float y2 = ButtonsY + (ButtonHeight + SpaceBetween) * 2;
	
		rect1 = new Rect(ButtonsX, y1, ButtonWidth, ButtonHeight);
		rect2 = new Rect(ButtonsX, y2, ButtonWidth, ButtonHeight);;
	}
}

