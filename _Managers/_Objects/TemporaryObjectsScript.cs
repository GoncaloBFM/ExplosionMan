using UnityEngine;
using System.Collections;

public class TemporaryObjectsScript : MonoBehaviour {

    public Transform ParticlesRepository;

    public static TemporaryObjectsScript Instance {
        private set;
        get;
    }

    public void DisableParticles() {
        foreach (Transform child in ParticlesRepository) {
            child.GetComponent<ParticleRenderer>().enabled = false;
        }
    }

    private void Awake() {
        Instance = this;
    }
}