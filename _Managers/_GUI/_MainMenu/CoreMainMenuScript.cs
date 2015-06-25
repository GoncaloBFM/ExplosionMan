using UnityEngine;
using System.Collections;

public class CoreMainMenuScript : MonoBehaviour {

	public enum Page {Front, Register, LevelSelect, Options, Credits}

	private Page _currentPage;

	private FrontMainMenuScript frontMainMenuScript;
	private LevelSelectMainMenuScript levelSelectMainMenuScript;
	private RegisterMainMenuScript registerMainMenuScript;
	private OptionsMainMenuScript optionsMainMenuScript;
	private CreditsMainMenuScript creditsMainMenuScript;


	public static CoreMainMenuScript Instance {
		get;
		private set;
	}

	public Page CurrentPage {
		set{
			if (value != _currentPage) {
				_currentPage = value;
			}
		}
		get{
			return _currentPage;
		}
	}

	private void OnGUI() {
		switch (CurrentPage) {
		case Page.Front:
			frontMainMenuScript.DisplayFront();
			break;
		case Page.LevelSelect:
			levelSelectMainMenuScript.DisplayLevelSelect();
			break;
		case Page.Register:
			registerMainMenuScript.DysplayRegister();
			break;
		case Page.Options:
			optionsMainMenuScript.DisplayOptions();
			break;
		case Page.Credits:
			creditsMainMenuScript.DisplayCredits();
			break;
		}
	}

	private void Awake () {
		CurrentPage = Page.Front;

		frontMainMenuScript = GetComponent<FrontMainMenuScript>();
		levelSelectMainMenuScript = GetComponent<LevelSelectMainMenuScript>();
		registerMainMenuScript = GetComponent<RegisterMainMenuScript>();
		optionsMainMenuScript = GetComponent<OptionsMainMenuScript>();
		creditsMainMenuScript = GetComponent<CreditsMainMenuScript>();
	}

}
