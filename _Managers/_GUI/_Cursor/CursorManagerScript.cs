using UnityEngine;
using System.Collections;

public class CursorManagerScript : MonoBehaviour {

	public bool EnableCursorOnAwake;
	private bool _cursorEnabled;

	public static CursorManagerScript Instance {
		get;
		private set;
	}

	public bool CursorEnabled {
		get {
			return _cursorEnabled;
		} set {
			Screen.showCursor = value;
			Screen.lockCursor = !value;
			_cursorEnabled = value;
		}
	}

	private void Awake() {
		Instance = this;
		CursorEnabled = EnableCursorOnAwake;
	}
}
