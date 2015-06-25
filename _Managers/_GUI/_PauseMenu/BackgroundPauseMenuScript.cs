using UnityEngine;
using System.Collections;

public class BackgroundPauseMenuScript : MonoBehaviour {

	public Texture Content;

	private Rect rect;


	public void DisplayBackground(Rect rect) {
		GUI.DrawTexture(rect, Content, ScaleMode.StretchToFill);
	}

}
