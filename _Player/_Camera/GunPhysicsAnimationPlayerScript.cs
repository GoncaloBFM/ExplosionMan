using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunPhysicsAnimationPlayerScript : MonoBehaviour {

	public Transform CameraTransform;
	public Transform Player;
	public float MaxOffset;
	public int Delay;

	private Transform myTransform;
	private Rigidbody playerRigidbody;
	private Vector3 originalPosition;
	private List<Vector3> positionArray = new List<Vector3>();

	private void Awake() {
		myTransform = transform;
		playerRigidbody = Player.rigidbody;
		originalPosition = myTransform.localPosition;
	}

	private void Update () {
		Vector3 positionAverage = Vector3.zero;

		Vector3 offset = Player.InverseTransformDirection(playerRigidbody.velocity).normalized * MaxOffset; 

		positionArray.Add(new Vector3(originalPosition.x * (-1 * offset.x + 1),
		                              originalPosition.y * (offset.y + 1),
		                              originalPosition.z * (-1 * offset.z + 1)));

		if (positionArray.Count >= Delay) {
			positionArray.RemoveAt(0);
		}

		for (int i = 0; i < positionArray.Count; i++) {
			positionAverage += positionArray[i];
		}

		positionAverage /= positionArray.Count;

		myTransform.localPosition = positionAverage;
	}

}