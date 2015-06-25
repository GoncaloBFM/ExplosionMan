using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractiveObjectsScript : MonoBehaviour {

    public List<Transform> InteractiveObjectsTransforms = new List<Transform>();
    
    private List<IInteractive> interactiveObjects = new List<IInteractive>();

    public static InteractiveObjectsScript Instance {
        private set;
        get;
    }


    private void Awake() {
        Instance = this;
        GetInteractiveObjects();
    }

    private void GetInteractiveObjects() {
        foreach(Transform interactiveObjectTransform in InteractiveObjectsTransforms) {
            interactiveObjects.Add((IInteractive) interactiveObjectTransform.GetComponent(typeof(IInteractive)));
        }
    }

    public void ResetStates() {
        foreach (IInteractive interactiveObject in interactiveObjects) {
            interactiveObject.ResetState();
        }
    }
}
