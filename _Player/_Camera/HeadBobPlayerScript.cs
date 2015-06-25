using UnityEngine;
using System.Collections;

public class HeadBobPlayerScript : MonoBehaviour {

	public Transform Player;

	public float BobbingSpeed;
	public float BobbingAmount;
	public float MinVelocity;

	private float  timer = 0;
	private Transform myTransform;
	private Rigidbody playerRigidbody;
	private Vector3 originalPosition;


	private void Awake() {
		myTransform = transform;
		playerRigidbody = Player.rigidbody;
		originalPosition = myTransform.localPosition;
	}

	private void Update() {
		float waveSlice = 0; 
		Vector3 velocity = playerRigidbody.velocity;
		float horizontal = Mathf.Abs(velocity.x);
		float vertical = Mathf.Abs(velocity.z);

		if ((horizontal > MinVelocity) || (vertical > MinVelocity)) {
			waveSlice = Mathf.Sin(timer); 
			timer += BobbingSpeed; 

			if (timer > Mathf.PI * 2) { 
				timer = timer - (Mathf.PI * 2); 
			} 

			if (waveSlice != 0) { 
				float translateChange = waveSlice * BobbingAmount; 
				float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical); 
				
				totalAxes = Mathf.Clamp (totalAxes, 0, 1); 
				translateChange = totalAxes * translateChange;
				myTransform.localPosition = Vector3.up * translateChange + originalPosition;
			}
		}
	}


}
