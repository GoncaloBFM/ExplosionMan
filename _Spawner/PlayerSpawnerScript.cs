using UnityEngine;
using System.Collections;

public class PlayerSpawnerScript : MonoBehaviour {

    public Transform Player;
    public Transform PlayerCamera;
    public bool IsTriggerEnabled;

    private CorePlayerScript corePlayerScript;
    private Vector3 spawnPosition;
    private Vector3 spawnRotation;
    private Vector3 worldGravity;
    private Vector3 playerGravity;

    public bool IsCurrentSpawner {
        get;
        set;
    }

    public void SpawnPlayer() {
        corePlayerScript.ResetState(spawnPosition, spawnRotation);
        GlobalGravityScript.Instance.WorldGravity = worldGravity;
        GlobalGravityScript.Instance.PlayerGravity = playerGravity;
    }

    private void OnTriggerEnter(Collider collider) {
        if (IsTriggerEnabled && !IsCurrentSpawner && (collider.tag == "Player")) {
            PlayerSpawnersManagerScript.Instance.CurrentPlayerSpawnerScript = this;
            InformationManagerScript.Instance.AddCheckpointTime();
            SetCurrentGravity(GlobalGravityScript.Instance.WorldGravity, GlobalGravityScript.Instance.PlayerGravity);
        }
    }

    private void Awake() {
        spawnPosition = transform.position;
        spawnRotation = transform.eulerAngles;

        corePlayerScript = Player.GetComponent<CorePlayerScript>();

        GetComponent<MeshRenderer>().enabled = false;
    }

    public void SetCurrentGravity(Vector3 currentWorldGravity, Vector3 currentPlayerGravity) {
        worldGravity = currentWorldGravity;
        playerGravity = currentPlayerGravity;
    }
}
