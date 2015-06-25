using UnityEngine;
using System.Collections;

public class CreditsMainMenuScript : MonoBehaviour {
	
	public GUIStyle style = new GUIStyle();

	private Rect rect;
	private GUIContent content;

	private CoreMainMenuScript coreMainMenuScript;


	private void Awake () {
		coreMainMenuScript = GetComponent<CoreMainMenuScript>();

		rect = new Rect(0, 0, Screen.width, Screen.height);
		content = new GUIContent(CreditsText.TEXT);
	}

	public void DisplayCredits() {
		if (GUI.Button(rect, content, style)) {
			coreMainMenuScript.CurrentPage = CoreMainMenuScript.Page.Front;
		}
	}	

}
