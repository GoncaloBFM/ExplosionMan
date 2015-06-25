using UnityEngine;
using System.Collections;

public class SkiEnabledHUDScript : MonoBehaviour, ResizebleGUI {

	public float X;
	public float Y;
	public float Width;
	public float Height;
	public Texture SkiEnabledTexture;
	public Texture SkiDisabledTexture;
	
	private Rect rect;
	private Texture currentTexture;
	private bool _skiEnabled;

	public static SkiEnabledHUDScript Instance { 
		get; 
		private set; 
	}

	public bool SkiEnabled {
		get {
			return _skiEnabled;
		}
		set {
			_skiEnabled = value;
			currentTexture = SkiEnabled ? SkiEnabledTexture : SkiDisabledTexture;
		}
	}

	public void DisplaySkiIcon() {
		GUI.DrawTexture(rect, currentTexture, ScaleMode.ScaleToFit);
	}

	public void UpdatePosition() {
		rect = new Rect(X, Y, Width, Height);
	}

	private void Awake() {
		Instance = this;

		UpdatePosition();
		currentTexture = SkiDisabledTexture;
	}
}
