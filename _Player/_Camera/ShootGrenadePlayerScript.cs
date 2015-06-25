using UnityEngine;
using System.Collections;


public class ShootGrenadePlayerScript : MonoBehaviour {
	
	private const int MIDDLE_MOUSE_BUTTON = 2;


	public Transform Player;
	public Transform Gun;
	public Transform Grenade;
	public float PropulsionZ;
	public Vector3 ShootingPosition; //0.196, -0.201, 1.05
	public float CookTime;

	private Transform myTransform;
	private GunRecoilAnimationPlayerScript gunRecoilAnimationPlayerScript;
	private Transform grenadeInstance;
	
	private bool isCooking;
	private bool isShooting;
	
	private void Awake() {
		myTransform = transform;
		gunRecoilAnimationPlayerScript = Gun.GetComponent<GunRecoilAnimationPlayerScript>();
	}

	private void Shoot() {
		if (grenadeInstance != null) {
			gunRecoilAnimationPlayerScript.PlayShotAnimation();
			grenadeInstance.parent = null;
			Rigidbody grenadeRigidbody = grenadeInstance.rigidbody;
			grenadeInstance.GetComponent<SphereCollider>().enabled = true;
			grenadeRigidbody.isKinematic = false;
			grenadeRigidbody.velocity = Player.rigidbody.velocity;
			grenadeRigidbody.AddForce(myTransform.forward * PropulsionZ, ForceMode.Impulse);
		}
	}

	private void Update() {
		if (Input.GetMouseButtonDown(MIDDLE_MOUSE_BUTTON)) {
			grenadeInstance = Instantiate(Grenade, myTransform.position, myTransform.rotation) as Transform;
			grenadeInstance.parent = myTransform;
			grenadeInstance.localPosition = ShootingPosition;
		} else if (Input.GetMouseButtonUp(MIDDLE_MOUSE_BUTTON)) {
			isShooting = true;
		}
	}

	
	private void FixedUpdate () {
		if (isShooting) {
			Shoot();
			isShooting = false;
		}
	}
} 