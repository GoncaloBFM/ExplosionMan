using UnityEngine;
using System.Collections;

public class GlobalGravityScript : MonoBehaviour {

	public Vector3 InitialPlayerGravity;
	public Vector3 InitialWorldGravity;
	public Transform Player;

	private Vector3 _playerGravity;
	private Vector3 _worldGravity;
	private GravityPlayerScript gravityPlayerScript;


	public static GlobalGravityScript Instance { 
		get; 
		private set; 
	}

	public Vector3 PlayerGravity {
		get{
			return _playerGravity;
		} 
		set{
			gravityPlayerScript.Gravity = value;
			_playerGravity = value;
		}
	}

	public Vector3 WorldGravity {
		get{
			return _worldGravity;
		}  
		set{
			Physics.gravity = value;
			_worldGravity = value;
		}
	}

	private void Awake () {
		Instance = this;
		gravityPlayerScript = Player.GetComponent<GravityPlayerScript>();
		WorldGravity = InitialWorldGravity;
		PlayerGravity = InitialPlayerGravity;
	}
}
