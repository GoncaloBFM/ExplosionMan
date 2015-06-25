using UnityEngine;
using System.Collections;

public class FrontMainMenuScript : MonoBehaviour {

	public float TitleX;
	public float TitleY;
	public float TitleWidth;
	public float TitleHeight;

	public float ButtonsX;
	public float ButtonsY;
	public float ButtonWidth; 
	public float ButtonHeight;
	public float SpaceBetween;

	public Texture TitleTexture;
	public GUIContent Content1 = new GUIContent();
	public GUIContent Content2 = new GUIContent();
	public GUIContent Content3 = new GUIContent();
	public GUIContent Content4 = new GUIContent();
	public GUIContent Content5 = new GUIContent();

	public GUIStyle ButtonStyle = new GUIStyle();


	private CoreMainMenuScript coreMainMenuScript;
	private float totalButtonHeight;
	private Rect titleRect;
	private Rect rect1;
	private Rect rect2;
	private Rect rect3;
	private Rect rect4;
	private Rect rect5;
	
	
	public void DisplayFront () {	
		if (GUI.Button(rect1, Content1, ButtonStyle)) {
			coreMainMenuScript.CurrentPage = CoreMainMenuScript.Page.LevelSelect;
		} else if (GUI.Button(rect2, Content2, ButtonStyle)) {
			//coreMainMenuScript.CurrentPage = CoreMainMenuScript.Page.Register;
		} else if (GUI.Button(rect3, Content3, ButtonStyle)) {
			//coreMainMenuScript.CurrentPage = CoreMainMenuScript.Page.Options
		} else if (GUI.Button(rect4, Content4, ButtonStyle)) {
			coreMainMenuScript.CurrentPage = CoreMainMenuScript.Page.Credits;
		} else if (GUI.Button(rect5, Content5, ButtonStyle)) {
			Application.Quit();
		}

		GUI.DrawTexture(titleRect, TitleTexture, ScaleMode.ScaleToFit);
	}
	
	private void Awake() {
		coreMainMenuScript = GetComponent<CoreMainMenuScript>();
	
		float y1 = ButtonsY + ButtonHeight + SpaceBetween;
		float y2 = ButtonsY + (ButtonHeight + SpaceBetween) * 2;
		float y3 = ButtonsY + (ButtonHeight + SpaceBetween) * 3;
		float y4 = ButtonsY + (ButtonHeight + SpaceBetween) * 4;
		float y5 = ButtonsY + (ButtonHeight + SpaceBetween) * 5;

		titleRect = new Rect(TitleX, TitleY, TitleWidth, TitleHeight);
		rect1 = new Rect(ButtonsX, y1, ButtonWidth, ButtonHeight);
		rect2 = new Rect(ButtonsX, y2, ButtonWidth, ButtonHeight);
		rect3 = new Rect(ButtonsX, y3, ButtonWidth, ButtonHeight);
		rect4 = new Rect(ButtonsX, y4, ButtonWidth, ButtonHeight);
		rect5 = new Rect(ButtonsX, y5, ButtonWidth, ButtonHeight);
	}
}
