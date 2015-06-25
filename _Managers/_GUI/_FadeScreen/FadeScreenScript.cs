using UnityEngine;
using System.Collections;


public class FadeScreenScript : MonoBehaviour { 
	
	public Color StartingScreenColor;
	public int StartingScreenDepth;

	private GUIStyle backgroundStyle = new GUIStyle();
	private Texture2D texture;
	private bool isChangingBackground;
	private Rect rect;
	private Color currentColor;
	private int currentDepth;


	public static FadeScreenScript Instance {
		get;
		private set;
	}

	public void FadeInBackground(Color newScreenColor, int depth, float fadeDuration, bool disableWhenFinished) {
		currentDepth = depth;
		StartCoroutine(FadeBackgroundCoroutine(newScreenColor, fadeDuration, false, disableWhenFinished));
	}

	public void FadeOutBackground(float fadeDuration, bool disableWhenFinished) {
		StartCoroutine(FadeBackgroundCoroutine(new Color(0, 0, 0, 0), fadeDuration, false, disableWhenFinished));
	}

	public void FadeInOutBackground(Color newScreenColor, int depth, float fadeDuration, bool disableWhenFinished) {
		currentDepth = depth;
		float halfFadeDuration = fadeDuration/2f;
		StartCoroutine(FadeBackgroundCoroutine(newScreenColor, halfFadeDuration, true, disableWhenFinished));
	}

	public void SetCurrentBackgroundColor(Color newScreenColor, int depth) {
		currentDepth = depth;
		ChangeScreenColor(newScreenColor);
	}

	private void Awake() {		
		Instance = this;

		texture = new Texture2D(1, 1);      
		backgroundStyle.normal.background = texture;
		rect = new Rect(-10, -10, Screen.width + 10, Screen.height + 10);

		currentColor = StartingScreenColor;
		currentDepth = StartingScreenDepth;

		SetCurrentBackgroundColor(currentColor, currentDepth);
	}

	private IEnumerator FadeBackgroundCoroutine(Color newScreenColor, float time, bool fadeBack, bool disableWhenFinished) { 
		if (!isChangingBackground) {
			enabled = true;
			isChangingBackground = true;
			Color originalColor = currentColor;
			float p1 = 0.0f;
			float rate = 1.0f/time;
			while (p1 < 1.0f) {
				p1 += Time.deltaTime * rate;
				ChangeScreenColor(Color.Lerp(originalColor, newScreenColor, p1));
				yield return null;
			}
			if (fadeBack) {
				originalColor = currentColor;
				p1 = 0.0f;
				while (p1 < 1.0f) {
					p1 += Time.deltaTime * rate;
					ChangeScreenColor(Color.Lerp(originalColor, new Color(0, 0, 0, 0), p1));
					yield return null;
				}
			}
			if (disableWhenFinished) {
				ChangeScreenColor(new Color(0, 0, 0, 0));
				enabled = false;
			}
			isChangingBackground = false;
		}
	}
	
	private void ChangeScreenColor(Color newScreenColor) {
		currentColor = newScreenColor;
		texture.SetPixel(0, 0, currentColor);
		texture.Apply();
	}

	private void OnGUI() { 
		GUI.depth = currentDepth;
		GUI.Label(rect, texture, backgroundStyle);
	}
}