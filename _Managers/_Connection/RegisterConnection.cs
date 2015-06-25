using System;
using UnityEngine;
using System.Collections;


public static class RegisterConnection {

	public static IEnumerator Register(System.Action<ConnectionResult> callOnCompletion, string email, string username, string password) {
		string hash = StringEncoder.CalculateMD5Hash(email + username + password + ConfigConnectionScript.Key);

		string url = ConfigConnectionScript.RegisterUrl + "?" +
					 "email=" + WWW.EscapeURL(email) +
					 "&username=" + username + 
					 "&password=" + password + 
					 "&hash=" + hash;
		
		WWW result = new WWW(url);
		yield return result;

		ConnectionResult connectionResult = null;

		if (result.error == null) {
			connectionResult = new ConnectionResult(result.text);
		} else {
			connectionResult = new ConnectionResult(ConnectionResult.ErrorType.CouldNotConnect);
		}

		callOnCompletion(connectionResult);
	}

}