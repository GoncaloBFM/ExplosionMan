using UnityEngine;
using System.Collections;

public class MovementPlayerScript : MonoBehaviour {

    public Transform CameraTransform;
    public float RotationRate;

    public float DefaultVelocity;
    public float AirVelocityModifier;
    public float CrouchVelocityModifier;

    public float DefaultControl;
    public float AirControlModifier;
    public float CrouchControlModifier;

    private Transform myTransform;
    private bool jump;
    private CorePlayerScript corePlayerScript;
    private float verticalInput;
    private float horizontalInput;
    private float currentVelocity;
    private float currentControl;


    public void SetNewCurrentForce(bool isAirBorn, bool isCrouched, bool isSkiing) {
        currentControl = DefaultControl;
        currentVelocity = DefaultVelocity;
        if (corePlayerScript.IsAirBorn) {
            currentControl *= AirControlModifier;
            currentVelocity *= AirVelocityModifier;
        } else if (corePlayerScript.IsCrouched) {
            currentControl *= CrouchControlModifier;
            currentVelocity *= CrouchVelocityModifier;
        }
    }

    private void Awake() {
        myTransform = transform;
        corePlayerScript = GetComponent<CorePlayerScript>();
    }

    private void Update() {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate() {
        Vector3 targetVelocity = (myTransform.forward * verticalInput + myTransform.right * horizontalInput);
        if (Mathf.Abs(targetVelocity.x) + Mathf.Abs(targetVelocity.z) > 1) {
            targetVelocity.Normalize();
        }
        targetVelocity *= currentVelocity;
        Vector3 velocityChange = myTransform.InverseTransformDirection(targetVelocity - rigidbody.velocity);
        velocityChange = Vector3.ClampMagnitude(velocityChange, currentControl);
        velocityChange.y = 0;
        velocityChange = myTransform.TransformDirection(velocityChange);
        rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
    }
}