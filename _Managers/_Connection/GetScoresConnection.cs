using UnityEngine;
using System.Collections;

public class GetScoresConnection {

	public IEnumerator GetScores() {
		WWW result = new WWW(ConfigConnectionScript.GetScoreUrl);
		yield return result;
		
		if (result.error != null) {
			throw new System.Exception("There was an error getting the high scores: " + result.error);
		} else {
			//gameObject.guiText.text = hs_get.text; //
		}
	}

}
