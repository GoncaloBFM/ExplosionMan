using UnityEngine;
using System.Collections;

public class CorePauseMenuScript : MonoBehaviour {

	public enum Page {None,Front,Options}
	public bool IsPauseMenuAccessible;

	private Page _currentPage;
	
	private FrontPauseMenuScript frontPauseMenuScript;
	private OptionsPauseMenuScript optionsPauseMenuScript;


	public static CorePauseMenuScript Instance {
		get;
		private set;
	}

	public Page CurrentPage {
		set{
			if (value != _currentPage) {
				if (value == Page.None) {
					PauseGameScript.Instance.Paused = false;
					CursorManagerScript.Instance.CursorEnabled = false; 
				} else if (_currentPage == Page.None) {
					PauseGameScript.Instance.Paused = true;
					CursorManagerScript.Instance.CursorEnabled = true; 
				}
				_currentPage = value;
			}
		}
		get{
			return _currentPage;
		}
	}

	private void OnGUI() {
		if (CurrentPage != Page.None) {
			GUIMatrixScript.Instance.Update();
			switch (CurrentPage) {
				case Page.Front:
					frontPauseMenuScript.DisplayFront();
					break;
				case Page.Options:
					optionsPauseMenuScript.DisplayOptions();
					break;
			}
		}
	}

	private void Awake () {
		Instance = this;

		CurrentPage = Page.None;
		frontPauseMenuScript = GetComponent<FrontPauseMenuScript>();
		optionsPauseMenuScript = GetComponent<OptionsPauseMenuScript>();
	}

	private void Update () {
		if (IsPauseMenuAccessible && Input.GetKeyDown(KeyCode.Escape)) {
			if (CurrentPage == Page.None) {
				CurrentPage = Page.Front;
			} else {
				CurrentPage = Page.None;
			}
		}
	}
}
