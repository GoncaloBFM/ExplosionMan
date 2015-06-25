using UnityEngine;
using System.Collections;

public class GravityPlayerScript : MonoBehaviour {

    public float GravitySpinTime;

    private Transform myTransform;
    private Rigidbody myRigidbody;
    private Vector3 _gravity;
    private MovementPlayerScript movementPlayerScript;

    public Vector3 Gravity {
        set {
            if (value == Vector3.zero) {
                movementPlayerScript.enabled = false;
            } else if (value != _gravity) {
                if (!movementPlayerScript.enabled) {
                    movementPlayerScript.enabled = true;
                }

                Vector3 gravityAlongLocalZAxis = myTransform.forward * Vector3.Dot(value, myTransform.forward);
                Vector3 gravityInLocalXYPlane = value - gravityAlongLocalZAxis;
                Quaternion target = Quaternion.LookRotation(myTransform.forward, -gravityInLocalXYPlane);

                StopAllCoroutines();
                StartCoroutine(ChangeRotationOverTime(target, GravitySpinTime));
            }
            _gravity = value;
        }
        get {
            return _gravity;
        }
    }

    private IEnumerator ChangeRotationOverTime(Quaternion target, float time) {
        float p1 = 0.0f;
        float rate = 1.0f / time;
        while (p1 < 1.0f) {
            p1 += Time.deltaTime * rate;
            myTransform.rotation = Quaternion.Euler(myTransform.eulerAngles.x,
                                                    myTransform.eulerAngles.y,
                                                    Quaternion.Slerp(myTransform.rotation, target, p1).eulerAngles.z);
            yield return null;
        }
    }

    private void Awake() {
        myTransform = transform;
        myRigidbody = myTransform.rigidbody;
        movementPlayerScript = myTransform.GetComponent<MovementPlayerScript>();
    }

    private void FixedUpdate() {
        myRigidbody.AddForce(Gravity);
    }
}