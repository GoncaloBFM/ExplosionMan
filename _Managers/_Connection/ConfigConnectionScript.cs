using UnityEngine;
using System.Collections;

public class ConfigConnectionScript : MonoBehaviour {

	public string _key;
	public string _urlTail;
	public string _postScoreUrl;
	public string _getScoreUrl;
	public string _loginUrl;
	public string _registerUrl;


	public static string Key {
		get;
		private set;
	}

	public static string UrlTail {
		get;
		private set;
	}

	public static string PostScoreUrl {
		get;
		private set;
	}
	
	public static string GetScoreUrl {
		get;
		private set;
	}

	public static string LoginUrl {
		get;
		private set;
	}

	public static string RegisterUrl {
		get;
		private set;
	}

	private void Awake() {
		Key = _key;
		UrlTail = _urlTail;
		PostScoreUrl = UrlTail + _postScoreUrl;
		GetScoreUrl = UrlTail + _getScoreUrl;
		LoginUrl = UrlTail + _loginUrl;
		RegisterUrl = UrlTail + _registerUrl;
	}

}
