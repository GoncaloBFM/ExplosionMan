using UnityEngine;
using System.Collections;

public class SkiPlayerScript : MonoBehaviour {

    private bool _isSkiing;
    private CorePlayerScript corePlayerScript;
    private MovementPlayerScript movementPlayerScript;


    public bool IsSkiing {
        set {
            if (_isSkiing != value) {
                corePlayerScript.IsSkiing = value;
                _isSkiing = value;
                movementPlayerScript.enabled = !value;
                SkiEnabledHUDScript.Instance.SkiEnabled = value;
            }
        }
        private get {
            return _isSkiing;
        }
    }

    private void Awake() {
        corePlayerScript = transform.GetComponent<CorePlayerScript>();
        movementPlayerScript = transform.GetComponent<MovementPlayerScript>();
        IsSkiing = false;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            IsSkiing = !IsSkiing;
        }
    }

}
