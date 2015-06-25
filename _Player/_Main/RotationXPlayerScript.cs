using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RotationXPlayerScript : MonoBehaviour {

	public bool InputEnabled;
	public float Sensitivity; //10
	public int Delay; //10

	private Transform myTransform;
	private float rotation;
	private Quaternion currentQuaternion;
	private Quaternion originalRotation;

	private List<float> rotationArray = new List<float>();


	public void SetRotation(float value) {
		rotation = value;
		rotationArray.Clear();
	}

	private void Awake() {
		myTransform = transform;
		originalRotation = myTransform.localRotation;
	}

	private void Update() {
		float rotationAverage = 0;
		float inputValue = 0;
		Vector3 rotationAxis;

		if(InputEnabled) {
			inputValue = Input.GetAxis("Mouse X");
		}
		rotationAxis = myTransform.up;

		rotation += inputValue * Sensitivity;

		rotationArray.Add(rotation);

		if (rotationArray.Count >= Delay) {
			rotationArray.RemoveAt(0);
		}

		for (int i = 0; i < rotationArray.Count; i++) {
			rotationAverage += rotationArray[i];
		}

		rotationAverage /= rotationArray.Count;
		currentQuaternion = Quaternion.AngleAxis (rotationAverage, rotationAxis);

		myTransform.localEulerAngles = new Vector3(myTransform.localEulerAngles.x, 
		                                      	    (originalRotation * currentQuaternion).eulerAngles.y,
		                                            myTransform.localEulerAngles.z);
		
	}

}