using UnityEngine;
using System.Collections;

public class GravityTriggerScript : MonoBehaviour {

    public bool Active;
    public bool Hide;
    public bool ReverseGravity;
    public bool UndoOnExit;
    public Vector3 NewPlayerGravity;
    public Vector3 NewWorldGravity;

    private GlobalGravityScript globalGravityScript;
    private Vector3 originalPlayerGravity;
    private Vector3 originalWorldGravity;


    private void Awake() {
        if (Hide) {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider collider) {
     
        if ((collider.tag == "Player") && Active) {
            originalPlayerGravity = GlobalGravityScript.Instance.PlayerGravity;
            originalWorldGravity = GlobalGravityScript.Instance.WorldGravity;

            if (ReverseGravity) {
                GlobalGravityScript.Instance.PlayerGravity = -originalPlayerGravity;
                GlobalGravityScript.Instance.WorldGravity = -originalWorldGravity;
            } else {
                GlobalGravityScript.Instance.PlayerGravity = NewPlayerGravity;
                GlobalGravityScript.Instance.WorldGravity = NewWorldGravity;
            }
        }
    }

    private void OnTriggerExit(Collider collider) {
        if (UndoOnExit && (collider.tag == "Player") && Active) {
            GlobalGravityScript.Instance.PlayerGravity = originalPlayerGravity;
            GlobalGravityScript.Instance.WorldGravity = originalWorldGravity;
        }
    }

}
