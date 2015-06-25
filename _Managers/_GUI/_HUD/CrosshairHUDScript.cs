using UnityEngine;
using System.Collections;


public class CrosshairHUDScript : MonoBehaviour, ResizebleGUI {

	public Texture CrosshairImage;

	private Rect rect;

	private void Awake () {
		UpdatePosition();
	}

	public void UpdatePosition() {
		rect = new Rect((GUIMatrixScript.OriginalWidth / 2) - (CrosshairImage.width / 2),
		                (GUIMatrixScript.OriginalHeight / 2) - (CrosshairImage.height / 2),
		                CrosshairImage.width, CrosshairImage.height);
	}

	public void DisplayCrosshair () { 
		GUI.DrawTexture(rect, CrosshairImage);
	}
}
