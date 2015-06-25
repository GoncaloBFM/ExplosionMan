using UnityEngine;
using System.Collections;

public class GrenadeBehaviourScript : MonoBehaviour {

	public GameObject Particles;
	public float CookTime;
	public float Radius;
	public float Power;
	public float UpwardsModifier;

	private Transform myTransform;
	private float timer;


	private void Awake() {
		myTransform = transform;
		StartCoroutine(Explode(CookTime));
	}

	private IEnumerator Explode(float cookTime) {
		yield return new WaitForSeconds(cookTime);
			
		Vector3 explosionPosition = myTransform.position;
		Collider[] colliders;

		SoundEffectsScript.Instance.PlayExplosionSound();
		Instantiate(Particles, explosionPosition, Quaternion.identity);
		colliders = Physics.OverlapSphere(explosionPosition, Radius);
		foreach (Collider collider in colliders) {
			if (collider.rigidbody != null) {
				collider.rigidbody.AddExplosionForce(Power, explosionPosition, Radius, UpwardsModifier, ForceMode.Impulse);
			}
		}
		
		Destroy(gameObject);
	}

}
