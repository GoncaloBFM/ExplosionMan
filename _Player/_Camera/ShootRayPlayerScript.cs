using UnityEngine;
using System.Collections;


public class ShootRayPlayerScript : MonoBehaviour {

	private const int LEFT_MOUSE_BUTTON = 0;


	public Transform Player;
	public Transform Gun;
	public GameObject Particles;
	public Transform TempObjsRepository;
	public float OthersEffectRadius; //5			//Explosion radius on other objects
	public float OthersExplosionPower; //10			//Explosion power on other objects
	public float OthersUpwardsModifier; //0.1		//Explosion upwards modifier on other objects
	public float OthersDirectShotModifier;//20		//Direct shot modifier on other objects
	public float PlayerEffectMinRadius;				//Explosion minimum radius on player
	public float PlayerEffectMaxRadius;				//Explosion maximum radius on player
	public float PlayerDirectReactionForce; //15	//Player explosion reaction force
	public int MaxAmmo; //1
	public float ReloadTimePerBullet; //0.5

	private Transform myTransform;
	private float currentReloadTime;
	private int currentAmmo;
	private bool isShooting;
	private GunRecoilAnimationPlayerScript gunRecoilAnimationPlayerScript;
	private RaycastHit hit;
	private float currentReactionPercentage;
	private bool isHit;
	

	private void Awake() {
		myTransform = transform;
		currentAmmo = MaxAmmo;
		currentReloadTime = 0;
		isShooting = false;
		currentReactionPercentage = 0;
		isHit = false;

		ReloadHUDScript.Instance.SetMaxAmmo(MaxAmmo);
		ReloadHUDScript.Instance.SetReloadTimePerBullet(ReloadTimePerBullet);

		gunRecoilAnimationPlayerScript = Gun.GetComponent<GunRecoilAnimationPlayerScript>();
	}
	
	private void Reload() {
		float addReload = Time.deltaTime;

		if (currentReloadTime < ReloadTimePerBullet) {
			currentReloadTime += addReload;
			ReloadHUDScript.Instance.Reload(currentAmmo, addReload);
		} else {
			currentReloadTime = 0;
			currentAmmo++;
		}
	}

	private void Shoot() {
	

		currentAmmo--;
		ReloadHUDScript.Instance.DecrementAmmo(currentAmmo);
		gunRecoilAnimationPlayerScript.PlayShotAnimation();

		if(isHit) {
			Vector3 explosionPosition = hit.point;

			GameObject particles = Instantiate(Particles, explosionPosition, Quaternion.identity) as GameObject;
			particles.transform.parent = TempObjsRepository;

			if (hit.rigidbody != null) {
				hit.transform.rigidbody.AddForceAtPosition(myTransform.forward * OthersDirectShotModifier, explosionPosition, ForceMode.Impulse);
			}

			Player.collider.enabled = false;
			Collider[] colliders = Physics.OverlapSphere(explosionPosition, OthersEffectRadius);
			Player.collider.enabled = true;

			foreach (Collider collider in colliders) {
				if (collider.rigidbody != null) {
					collider.rigidbody.AddExplosionForce(OthersExplosionPower, explosionPosition, OthersEffectRadius, OthersUpwardsModifier, ForceMode.Impulse);
				}
			}
			if (currentReactionPercentage > 0) {
				Player.rigidbody.AddForceAtPosition(-myTransform.forward * currentReactionPercentage * PlayerDirectReactionForce, myTransform.position, ForceMode.Impulse);
			}

			SoundEffectsScript.Instance.PlayExplosionSound(explosionPosition);
		}

	}

	private float GetCurrentReactionPercentage(Vector3 explosionPosition) {
		float distanceToHit = Vector3.Distance(myTransform.parent.position, explosionPosition);
		if (distanceToHit <= PlayerEffectMaxRadius) {
			if (distanceToHit > PlayerEffectMinRadius) {
				return 1f - ((distanceToHit - PlayerEffectMinRadius) / (PlayerEffectMaxRadius - PlayerEffectMinRadius));
			} else {
				return 1;
			}
		} else {
			return 0;
		}
	}

	private void Update() {
		isHit = Physics.Raycast(myTransform.position, myTransform.forward, out hit);
		if(isHit) {
			currentReactionPercentage = GetCurrentReactionPercentage (hit.point);
		} else {
			currentReactionPercentage = 0;
		}

		ShotEffectHUDScript.Instance.SetShotEffect(currentReactionPercentage);

		if (Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON) && !isShooting) {
			if (currentAmmo > 0) {
				isShooting = true;
			} else {
				SoundEffectsScript.Instance.PlayNoAmmoSound();
			}
		} 

		if (currentAmmo < MaxAmmo) {
			Reload();
		}
	}

	private void FixedUpdate () {
		if (isShooting) {
			Shoot();
			isShooting = false;
		}
	}
}  