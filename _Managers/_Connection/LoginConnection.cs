using UnityEngine;
using System.Collections;


public static class LoginConnection {

	public static IEnumerator Login(string username, string password) {

		string hash = StringEncoder.CalculateMD5Hash(username + password + ConfigConnectionScript.Key);

		string url = ConfigConnectionScript.LoginUrl + "?" +
			"username=" + username + 
			"&password=" + password + 
			"&hash=" + hash;
		
		WWW result = new WWW(url);
		yield return result;

		if (result.error != null) {
			throw new System.Exception("There was an error with the user login: " + result.error);
		} else {
			//gameObject.guiText.text = hs_get.text; //
		}
	}

}