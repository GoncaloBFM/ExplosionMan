using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelSelectMainMenuScript : MonoBehaviour {

	public GUIStyle LevelSelectButtonStyle = new GUIStyle();
	public GUIStyle BackButtonStyle = new GUIStyle();
	public GUIContent BackButtonContent = new GUIContent();
	public int NumberOfLevels;
	public int NumberOfRows;
	public int NumberColumns;
	public float ButtonWidth;
	public float ButtonHeight;
	public float ButtonXOffset;
	public float ButtonYOffset;

	private CoreMainMenuScript coreMainMenuScript;
	private List<Rect> levelRectList = new List<Rect>();


	private void Awake () {
		coreMainMenuScript = GetComponent<CoreMainMenuScript>();

		float startingX = (Screen.width / 2f) - (((ButtonWidth + ButtonXOffset) * NumberColumns) / 2f);
		float startingY = (Screen.height / 2f) - (((ButtonHeight + ButtonYOffset) * NumberOfRows) / 2f);

		for (int i = 0; i < NumberOfRows; i++) {
			float y = startingY + (ButtonHeight + ButtonYOffset) * i;
			
			for (int j = 0; j < NumberColumns; j++) {
				float x = startingX + (ButtonWidth + ButtonXOffset) * j;
				levelRectList.Add(new Rect(x, y, ButtonWidth, ButtonHeight));
			}
		}
	}

	public void DisplayLevelSelect() {
		if (GUI.Button(levelRectList[0], BackButtonContent, BackButtonStyle)){
			coreMainMenuScript.CurrentPage = CoreMainMenuScript.Page.Front;
		}
		for (int i = 1; i <= NumberOfLevels; i++) {
			GUIContent buttonContent = new GUIContent(i.ToString());
			if (GUI.Button(levelRectList[i], buttonContent, LevelSelectButtonStyle)) {
				Application.LoadLevel("Level"+i); 
			}
		}
	}
}