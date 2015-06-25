using UnityEngine;
using System.Collections;

public class CoreGameStateScript : MonoBehaviour {

    public enum GameState { WarmUp, MidLevel, LevelFinished }
    public Transform Player;

    private GameState _currentGameState;
    private CorePlayerScript corePlayerScript;
    private WarmUpGameStateScript warmUpGameStateScript;


    public static CoreGameStateScript Instance {
        get;
        private set;
    }

    public void TotalLevelReset() {
        ResetObjects();
        CorePauseMenuScript.Instance.CurrentPage = CorePauseMenuScript.Page.None;
        CoreHUDScript.Instance.enabled = false;
        PlayerSpawnersManagerScript.Instance.ResetToStartingSpawner();
        PlayerSpawnersManagerScript.Instance.CallSpawnPlayer();
        TimerScript.Instance.ResetTimer();
        InformationManagerScript.Instance.ResetInformation();
        CurrentGameState = GameState.WarmUp;
    }

    public void CheckpointLevelReset() {
        ResetObjects();
        PlayerSpawnersManagerScript.Instance.CallSpawnPlayer();
    }

    public GameState CurrentGameState {
        get {
            return _currentGameState;
        }
        set {
            _currentGameState = value;
            switch (_currentGameState) {
                case GameState.WarmUp:
                    corePlayerScript.InputScriptsEnabled = false;
                    corePlayerScript.AnimationScriptsEnabled = false;
                    CorePauseMenuScript.Instance.IsPauseMenuAccessible = false;
                    warmUpGameStateScript.StartWarmUpTimer();
                    PreGameCountdownScript.Instance.ShowCountdown(warmUpGameStateScript.WarmUpTime);
                    break;
                case GameState.MidLevel:
                    PauseGameScript.Instance.Paused = false;
                    corePlayerScript.InputScriptsEnabled = true;
                    corePlayerScript.AnimationScriptsEnabled = true;
                    CoreHUDScript.Instance.enabled = true;
                    CorePauseMenuScript.Instance.IsPauseMenuAccessible = true;
                    break;
                case GameState.LevelFinished:
                    corePlayerScript.InputScriptsEnabled = false;
                    corePlayerScript.AnimationScriptsEnabled = false;
                    CoreHUDScript.Instance.enabled = false;
                    CorePauseMenuScript.Instance.IsPauseMenuAccessible = false;
                    Player.rigidbody.isKinematic = true;
                    InformationManagerScript.Instance.SetTotalTime();
                    CoreEndMenuScript.Instance.GetGameInformation();
                    CoreEndMenuScript.Instance.PlayWinningTransition();
                    break;
            }
        }
    }

    private void ResetObjects() {
        TemporaryObjectsScript.Instance.DisableParticles();
        InteractiveObjectsScript.Instance.ResetStates();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R) && (CurrentGameState == GameState.MidLevel)) {
            TotalLevelReset();
        }
    }

    private void Awake() {
        Instance = this;

        corePlayerScript = Player.GetComponent<CorePlayerScript>();
        warmUpGameStateScript = GetComponent<WarmUpGameStateScript>();

        TotalLevelReset();
    }
}
