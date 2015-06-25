using UnityEngine;
using System.Collections;

public class JumpPlayerScript : MonoBehaviour {

    private const int RIGHT_MOUSE_BUTTON = 1;


    public float JumpForce; //5

    private Transform myTransform;
    private bool _isAirBorn;
    private bool startJumping;
    private float groundDistance;
    private CorePlayerScript corePlayerScript;


    public bool IsAirBorn {
        set {
            if (value != _isAirBorn) {
                corePlayerScript.IsAirBorn = value;
                _isAirBorn = value;
            }
        }
        private get {
            return _isAirBorn;
        }
    }

    private void Awake() {
        myTransform = transform;
        corePlayerScript = transform.GetComponent<CorePlayerScript>();

        IsAirBorn = false;
    }

    private bool IsCollidingWithGround() {
        return Physics.Raycast(myTransform.position, -myTransform.up, collider.bounds.extents.y + 0.1f);
    }

    private void Jump() {
        myTransform.rigidbody.AddForce(myTransform.up * JumpForce, ForceMode.Impulse);
    }

    private void FixedUpdate() {
        if (startJumping) {
            Jump();
            startJumping = false;
        }
    }

    private void Update() {
        IsAirBorn = !IsCollidingWithGround();

        if (!startJumping && !IsAirBorn && Input.GetMouseButtonDown(RIGHT_MOUSE_BUTTON)) {
            startJumping = true;
        }
    }
}
