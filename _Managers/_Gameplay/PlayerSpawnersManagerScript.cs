using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSpawnersManagerScript : MonoBehaviour {

    public Transform StartingSpawnerTransform;
    public Transform PlayerSpawnersRepository;

    public float SpawnTransitionTime;
    public int SpawnTransitionDepth;
    public Color SpawnTransitionColor;


    private PlayerSpawnerScript _currentPlayerSpawnerScript;
    private List<PlayerSpawnerScript> allPlayerSpawnerScripts = new List<PlayerSpawnerScript>();

    public static PlayerSpawnersManagerScript Instance {
        get;
        private set;
    }

    public PlayerSpawnerScript CurrentPlayerSpawnerScript {
        get {
            return _currentPlayerSpawnerScript;
        }
        set {
            if (_currentPlayerSpawnerScript != null) {
                _currentPlayerSpawnerScript.IsCurrentSpawner = false;
                _currentPlayerSpawnerScript.IsTriggerEnabled = false;
            }
            _currentPlayerSpawnerScript = value;
            _currentPlayerSpawnerScript.IsCurrentSpawner = true;
        }
    }

    public void CallSpawnPlayer() {
        FadeScreenScript.Instance.SetCurrentBackgroundColor(SpawnTransitionColor, SpawnTransitionDepth);
        FadeScreenScript.Instance.FadeOutBackground(SpawnTransitionTime, true);
        CurrentPlayerSpawnerScript.SpawnPlayer();
    }

    public void ResetToStartingSpawner() {
        CurrentPlayerSpawnerScript = StartingSpawnerTransform.GetComponent<PlayerSpawnerScript>();
        CurrentPlayerSpawnerScript.SetCurrentGravity(GlobalGravityScript.Instance.InitialWorldGravity, GlobalGravityScript.Instance.InitialPlayerGravity);
        ResetSpawnersStates(false);
    }

    private void Awake() {
        Instance = this;

        foreach (Transform spawner in PlayerSpawnersRepository) {
            allPlayerSpawnerScripts.Add(spawner.GetComponent<PlayerSpawnerScript>());
        }
    }

    private void ResetSpawnersStates(bool resetCurrentSpawner) {
        foreach (PlayerSpawnerScript spawnerScript in allPlayerSpawnerScripts) {
            if ((!resetCurrentSpawner && !spawnerScript.IsCurrentSpawner) || resetCurrentSpawner) {
                spawnerScript.IsTriggerEnabled = true;
                spawnerScript.IsCurrentSpawner = false;
            }
        }
    }
}
