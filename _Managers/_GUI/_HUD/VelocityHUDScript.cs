using UnityEngine;
using System.Collections;

public class VelocityHUDScript : MonoBehaviour, ResizebleGUI {

	public Transform Player; 
	public float X;
	public float Y;
	public float Width;
	public float Height;
	public GUIStyle Style = new GUIStyle();

	private float currentVelocity;
	private Rigidbody playerRigidbody;
	private Rect rect;


	public void DisplaySpeedometer() {
		GUI.Label(rect, GetCurrentVelocity().ToString("F2") + "m/s", Style);
	}

	public void UpdatePosition() {
		rect = new Rect(X, Y, Width, Height);
	}

	private float GetCurrentVelocity() {
		return playerRigidbody.velocity.magnitude;
	}

	private void Awake () {
		playerRigidbody = Player.rigidbody;
		UpdatePosition();
	}

}