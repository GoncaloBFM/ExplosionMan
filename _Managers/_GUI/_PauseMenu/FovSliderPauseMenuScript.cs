using UnityEngine;
using System.Collections;

public class FovSliderPauseMenuScript : MonoBehaviour {

	public Transform PlayerCameraTransform;

	public float LabelY;
	public float SliderY;
	public float SliderWidth;
	public float SpaceBeetwen1;
	public float SpaceBeetwen2;
	public float Height;
	public float MaxFov;
	public float MinFov;
	
	public GUIContent DescriptionLabelContent;
	public GUIStyle DescriptionLabelStyle;
	public GUIStyle ValueLabelStyle;

	private GUIContent valueLabelContent = new GUIContent();
	private Camera playerCamera;
	private Rect sliderRect;
	private Rect descriptionLabelRect;
	private Rect valueLabelRect;

	public void DisplayFovSlider () {
		GUI.Label(descriptionLabelRect, DescriptionLabelContent, DescriptionLabelStyle);
		playerCamera.fieldOfView = Mathf.Round(GUI.HorizontalSlider(sliderRect, playerCamera.fieldOfView, MinFov, MaxFov));
		valueLabelContent.text = (playerCamera.fieldOfView).ToString();
		GUI.Label(valueLabelRect, valueLabelContent, ValueLabelStyle);
	}

	private void Awake () {
		playerCamera = PlayerCameraTransform.camera;

		float totalWidth = SliderWidth + SpaceBeetwen1 + SpaceBeetwen2;
		float labelX = GUIMatrixScript.OriginalWidth/2f - totalWidth/2f;
		float sliderX = labelX + SpaceBeetwen1;

		descriptionLabelRect = new Rect(labelX, LabelY, 0, Height);
		sliderRect = new Rect(sliderX, SliderY, SliderWidth, Height);
		valueLabelRect = new Rect(sliderX + SpaceBeetwen2 + SliderWidth, LabelY, 0, Height);
	}
}
