using UnityEngine;
using System.Collections;


public class CrouchPlayerScript : MonoBehaviour {
	
	public Transform Cam;
	public float ColliderHeightModifier; //.2
	public float ColliderCenterModifier; //.4
	public float CrouchSpeed; //.2
	public float GetUpSpeed; //.2

	private Transform myTransform;
	private CapsuleCollider myCollider;

	private bool _isCrouched;
	private float originalColliderHeight;
	private float targetColliderHeight;
	private Vector3 originalCollliderCenter;
	private Vector3 targetColliderCenter;
	private bool getUp;
	private CorePlayerScript corePlayerScript;
	
	public bool IsCrouched {
		set{
			corePlayerScript.IsCrouched = value;
			_isCrouched = value;
		}
		private get {
			return _isCrouched;
		}
	}

	private void Awake () {
		myTransform = transform;
		myCollider = transform.collider as CapsuleCollider;
		corePlayerScript = myTransform.GetComponent<CorePlayerScript>();

		IsCrouched = false;
		originalColliderHeight = myCollider.height;
		targetColliderHeight = originalColliderHeight * ColliderHeightModifier;
		originalCollliderCenter = myCollider.center;
		targetColliderCenter = originalCollliderCenter * ColliderCenterModifier;

	}

	private void Update () {
		if (Input.GetKeyDown(KeyCode.LeftControl)) {
			getUp = false;
			StartCoroutine(ChangeCrouchOverTime(CrouchSpeed, targetColliderHeight, targetColliderCenter, true));
		} else if (Input.GetKeyUp(KeyCode.LeftControl)) {
			getUp = true;
		} if (getUp && IsAbleToGetUp()) {
			getUp = false;
			StartCoroutine(ChangeCrouchOverTime(GetUpSpeed, originalColliderHeight, originalCollliderCenter, false));
		}
	}

	private IEnumerator ChangeCrouchOverTime (float time, float targetHeight, Vector3 targetCenter, bool crouch) {
		float p1 = 0.0f;
		float rate = 1.0f/time;

		float startHeight = myCollider.height;
		Vector3 startCenter = myCollider.center;

		while (p1 < 1.0f) {
			myCollider.height = Mathf.Lerp(startHeight, targetHeight, p1);
			myCollider.center = Vector3.Lerp(startCenter, targetCenter, p1);
			p1 += Time.deltaTime * rate;
			yield return null;
		}
	
		IsCrouched = crouch;
	}

	private bool IsAbleToGetUp() {
		bool result;
		float discount = 1f;
		float radiusDiscount = -.1f;

		Vector3 myTransformPosition = myTransform.position;
		Vector3 bottomPoint = new Vector3(myTransformPosition.x, 
		                                  myTransformPosition.y + targetColliderCenter.y - myCollider.radius + discount, 
		                                  myTransformPosition.z);
		Vector3 topPoint = new Vector3(bottomPoint.x, 
		                               bottomPoint.y + originalColliderHeight, 
		                               bottomPoint.z);

		myCollider.enabled = false;
		result = !(Physics.CheckCapsule(bottomPoint, topPoint, myCollider.radius + radiusDiscount));
		myCollider.enabled = true;

		return result;

	}

}
