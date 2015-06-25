using UnityEngine;
using System.Collections;

public class SoundEffectsScript : MonoBehaviour {
	
	public AudioSource PlayerOneShotSource;

	public AudioClip ExplosionSound;
	public AudioClip NoAmmoSound;

	private bool _playFootstepsSound;


	public static SoundEffectsScript Instance { 
		get; 
		private set; 
	}

	public void PlayExplosionSound(Vector3 position = new Vector3()) {
		AudioSource.PlayClipAtPoint(ExplosionSound, position, PlayerOneShotSource.volume);
	}

	public void PlayNoAmmoSound() {
		PlayerOneShotSource.PlayOneShot(NoAmmoSound);
	}

	private void Awake () {
		Instance = this;
	}

}
