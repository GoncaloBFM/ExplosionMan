using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InformationManagerScript : MonoBehaviour {
	
	public List<TimeElapsed> _checkpointTimes;

	private TimerScript timerScript;


	public static InformationManagerScript Instance {
		get;
		private set;
	}

	public int NumberOfRespawns {
		get;
		private set;
	}

	public TimeElapsed TotalTime {
		get;
		private set;
	}

	public void SetTotalTime() {
		TotalTime = timerScript.GetTimeElapsedFromStart();
	}
	
	public void ResetInformation() {
		_checkpointTimes = new List<TimeElapsed>();
		_checkpointTimes.Add (new TimeElapsed(0, 0, 0));
		NumberOfRespawns = 0;
	}

	public void IncrementNumberOfRespawns() {
		NumberOfRespawns++;
	}

	public List<TimeElapsed> CheckpointTimes {
		get {
			_checkpointTimes[_checkpointTimes.Count - 1] = timerScript.GetTimeElapsedFromMarker();
			return _checkpointTimes;
		}
		private set{
			_checkpointTimes = value;
		}
	}

	public int GetNumberOfCheckpoints() {
		return CheckpointTimes.Count;
	}

	public void AddCheckpointTime() {
		CheckpointTimes.Add(timerScript.GetTimeElapsedFromStart());
		timerScript.SetTimeMarker();
	}

	private void Awake() {
		Instance = this;
		timerScript = TimerScript.Instance;
	}
}
