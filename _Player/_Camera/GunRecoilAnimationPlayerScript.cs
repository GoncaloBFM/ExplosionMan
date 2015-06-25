using UnityEngine;
using System.Collections;

public class GunRecoilAnimationPlayerScript : MonoBehaviour {

	private Animation gunRecoilAnimationScript;


	private void Awake () { 
		gunRecoilAnimationScript = GetComponent<Animation>();
	}

	public void PlayShotAnimation () {
		gunRecoilAnimationScript.Play();
	}
}
