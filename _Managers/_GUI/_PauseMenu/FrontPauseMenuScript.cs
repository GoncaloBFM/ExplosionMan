using UnityEngine;
using System.Collections;

public class FrontPauseMenuScript : MonoBehaviour {

	public float Y;
	public float Width; 
	public float Height;
	public float SpaceBetween;

	public float BackgroundY;
	public float BackgroundWidth;
	public float BackgroundHeight;

	public GUIContent TitleContent = new GUIContent();
	public GUIContent Content1 = new GUIContent();
	public GUIContent Content2 = new GUIContent();
	public GUIContent Content3 = new GUIContent();
	public GUIContent Content4 = new GUIContent();
	public GUIContent Content5 = new GUIContent();

	public GUIStyle TitleStyle = new GUIStyle();
	public GUIStyle ButtonStyle = new GUIStyle();

	private CorePauseMenuScript corePauseMenuScript;
	private BackgroundPauseMenuScript backgroundPauseMenuScript;
	private float totalHeight;
	private Rect titleRect;
	private Rect rect1;
	private Rect rect2;
	private Rect rect3;
	private Rect rect4;
	private Rect rect5;
	private Rect backgroundRect;
	

	public void DisplayFront () {
		backgroundPauseMenuScript.DisplayBackground(backgroundRect);

		GUI.Label(titleRect, TitleContent, TitleStyle);

		//TODO: ButtonStyle
		if (GUI.Button(rect1, Content1)) {
			corePauseMenuScript.CurrentPage = CorePauseMenuScript.Page.None;
		} else if (GUI.Button(rect2, Content2)) {
			corePauseMenuScript.CurrentPage = CorePauseMenuScript.Page.None;
			CoreGameStateScript.Instance.CheckpointLevelReset();
		} else if (GUI.Button(rect3, Content3)) {
			CoreGameStateScript.Instance.TotalLevelReset();
		} else if (GUI.Button(rect4, Content4)) {
			corePauseMenuScript.CurrentPage = CorePauseMenuScript.Page.Options;
		} else if (GUI.Button(rect5, Content5)) {
			Application.LoadLevel("MainMenu");
		}
	}

	private void Awake() {
		corePauseMenuScript = GetComponent<CorePauseMenuScript>();
		backgroundPauseMenuScript = GetComponent<BackgroundPauseMenuScript>();
		
		float x = GUIMatrixScript.OriginalWidth/2f - Width/2f;
		float backgroundX = GUIMatrixScript.OriginalWidth/2f - BackgroundWidth/2f;

		float labelY = Y;
		float y1 = Y + Height + SpaceBetween;
		float y2 = Y + (Height + SpaceBetween) * 2;
		float y3 = Y + (Height + SpaceBetween) * 3;
		float y4 = Y + (Height + SpaceBetween) * 4;
		float y5 = Y + (Height + SpaceBetween) * 6;

		titleRect = new Rect(x, labelY, Width, Height);
		rect1 = new Rect(x, y1, Width, Height);
		rect2 = new Rect(x, y2, Width, Height);
		rect3 = new Rect(x, y3, Width, Height);
		rect4 = new Rect(x, y4, Width, Height);
		rect5 = new Rect(x, y5, Width, Height);

		backgroundRect = new Rect(backgroundX, BackgroundY, BackgroundWidth, BackgroundHeight);
	}
}
