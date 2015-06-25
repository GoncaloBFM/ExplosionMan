using UnityEngine;
using System.Collections;

public class CorePlayerScript : MonoBehaviour {

    public Transform PlayerCamera;

    private Transform myTransform;

    private bool _isAirBorn;
    private bool _isCrouched;
    private bool _isSkiing;

    private MovementPlayerScript movementPlayerScript;
    private RotationXPlayerScript rotationXPlayerScript;
    private RotationYPlayerScript rotationYPlayerScript;
    private JumpPlayerScript jumpPlayerScript;
    private CrouchPlayerScript crouchPlayerScript;
    private SkiPlayerScript skiPlayerScript;
    private ShootGrenadePlayerScript shootGrenadePlayerScript;
    private ShootRayPlayerScript shootRayPlayerScript;
    private HeadBobPlayerScript headBobPlayerScript;

    private bool _inputScriptsEnabled;
    private bool _animationScriptsEnabled;


    public bool InputScriptsEnabled {
        get {
            return _inputScriptsEnabled;
        }
        set {
            movementPlayerScript.enabled = value;
            rotationXPlayerScript.InputEnabled = value;
            rotationYPlayerScript.InputEnabled = value;
            jumpPlayerScript.enabled = value;
            crouchPlayerScript.enabled = value;
            skiPlayerScript.enabled = value;
            shootGrenadePlayerScript.enabled = value;
            shootRayPlayerScript.enabled = value;
            _inputScriptsEnabled = value;
        }
    }

    public bool AnimationScriptsEnabled {
        get {
            return _animationScriptsEnabled;
        }
        set {
            _animationScriptsEnabled = value;
            headBobPlayerScript.enabled = value;
        }
    }

    public bool IsAirBorn {
        get {
            return _isAirBorn;
        }
        set {
            _isAirBorn = value;
            movementPlayerScript.SetNewCurrentForce(_isAirBorn, _isCrouched, _isSkiing);
            headBobPlayerScript.enabled = isRunning;
        }
    }

    public bool IsCrouched {
        get {
            return _isCrouched;
        }
        set {
            _isCrouched = value;
            movementPlayerScript.SetNewCurrentForce(_isAirBorn, _isCrouched, _isSkiing);
        }
    }

    public bool IsSkiing {
        get {
            return _isSkiing;
        }
        set {
            _isSkiing = value;
            movementPlayerScript.SetNewCurrentForce(_isAirBorn, _isCrouched, _isSkiing);
            headBobPlayerScript.enabled = isRunning;
        }
    }

    public bool isRunning {
        get {
            return !(IsAirBorn || IsSkiing);
        }
    }

    public void ResetState(Vector3 newPosition, Vector3 newRotation) {
        skiPlayerScript.IsSkiing = false;
        myTransform.rigidbody.velocity = Vector3.zero;
        myTransform.position = newPosition;
        rotationXPlayerScript.SetRotation(newRotation.x);
        rotationYPlayerScript.SetRotation(newRotation.y);
    }

    private void Awake() {
        myTransform = transform;
        movementPlayerScript = GetComponent<MovementPlayerScript>();
        rotationXPlayerScript = GetComponent<RotationXPlayerScript>();
        rotationYPlayerScript = PlayerCamera.GetComponent<RotationYPlayerScript>();
        jumpPlayerScript = GetComponent<JumpPlayerScript>();
        crouchPlayerScript = GetComponent<CrouchPlayerScript>();
        skiPlayerScript = GetComponent<SkiPlayerScript>();
        shootRayPlayerScript = PlayerCamera.GetComponent<ShootRayPlayerScript>();
        shootGrenadePlayerScript = PlayerCamera.GetComponent<ShootGrenadePlayerScript>();
        headBobPlayerScript = PlayerCamera.GetComponent<HeadBobPlayerScript>();
    }

}
