using UnityEngine;
using System.Collections;

public class ReloadHUDScript : MonoBehaviour, ResizebleGUI {

	public float X; //10
	public float Y; //10
	public float Width; //50
	public float Height; //20

	public Texture BackgroundTexture;
	public Texture ForegroundTexture;

	private float[] ammoSlots;
	private int maxAmmo = 3;
	private float reloadTimePerBullet;

	
	public static ReloadHUDScript Instance { 
		get; 
		private set; 
	}

	public void SetMaxAmmo(int maxAmmo) {
		this.maxAmmo = maxAmmo;
	}

	public void SetReloadTimePerBullet(float reloadTimePerBullet) {
		this.reloadTimePerBullet = reloadTimePerBullet;

		for (int i = 0; i < ammoSlots.Length; i++) {
			ammoSlots[i] = reloadTimePerBullet;
		}
	}

	public void DecrementAmmo(int ammoSlot) {
		if (ammoSlot == maxAmmo - 1) {
			ammoSlots[ammoSlot] = 0;
		} else {
			ammoSlots[ammoSlot] = ammoSlots[ammoSlot + 1];
			ammoSlots[ammoSlot + 1] = 0;
		}
	}

	public void Reload(int ammoSlot, float addedReload) {
		ammoSlots[ammoSlot] += addedReload;
		if (ammoSlots[ammoSlot] > reloadTimePerBullet) {
			ammoSlots[ammoSlot] = reloadTimePerBullet;
		}
	}

	public void DisplayAmmoBar() {
		for (int i = 0; i < maxAmmo; i++) {
			DrawBar(X + 55 * i, Y, Width, Height, BackgroundTexture);
			DrawBar(X + 5 + 55 * i, Y + 3, (Width - 10) * (ammoSlots[i] / reloadTimePerBullet), Height - 6, ForegroundTexture);
		}
	}
	
	public void UpdatePosition() {
		//TODO: method 
	}

	private void Awake() {
		Instance = this;

		ammoSlots = new float[maxAmmo];
	}

	private void DrawBar(float x, float y, float width, float height, Texture texture) {
		GUI.DrawTexture(new Rect(x, y, width, height), texture, ScaleMode.StretchToFill);
	}

}
