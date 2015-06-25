using UnityEngine;
using System.Collections;

public class PostScoreConnection : MonoBehaviour {
	
		public IEnumerator PostScore(int user_id, int stage_id, int hours, int minutes, int seconds, int milliseconds) {
		string hash = StringEncoder.CalculateMD5Hash("" + user_id + stage_id + hours + minutes + seconds + milliseconds + ConfigConnectionScript.Key);
		
		string url = ConfigConnectionScript.PostScoreUrl + "?" + 
					 "user_id=" + user_id + 
				 	 "&stage_id=" + stage_id + 
					 "&hours=" + hours + 
					 "&minutes=" + minutes + 
					 "&seconds=" + seconds +
					 "&milliseconds=" + milliseconds +
					 "&hash=" + hash;
		
		// Post the URL to the site and create a download object to get the result.
		WWW result = new WWW(url);
		yield return result; // Wait until the download is done
		
		if (result.error != null) {
			throw new System.Exception("There was an error posting the score: " + result.error);
		}
	}


}
