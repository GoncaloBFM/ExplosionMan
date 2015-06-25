using UnityEngine;
using System.Collections;

public class GUIMatrixScript : MonoBehaviour {

	public const float OriginalWidth = 1920f;
	public const float OriginalHeight = 1080f;

	private float ratioX;
	private float ratioY;
	private Matrix4x4 matrix;

	public static GUIMatrixScript Instance { 
		get; 
		private set; 
	}

	public void CalculateNewMatrix() {
		ratioX = Screen.width / OriginalWidth;
		ratioY  = Screen.height / OriginalHeight;
		matrix = Matrix4x4.TRS (new Vector3(0, 0, 0), Quaternion.identity, new Vector3 (ratioX, ratioY, 1));
	}

	public void Update() {
		GUI.matrix = matrix;
	}

	private void Awake() {
		Instance = this;
		CalculateNewMatrix();
	}
}
