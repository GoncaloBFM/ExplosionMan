using UnityEngine;
using System.Collections;
using System;

public class VolumeSliderPauseMenuScript : MonoBehaviour {
	
	public Transform AudioSourceTransform;
	
	public float LabelY;
	public float SliderY;
	public float SliderWidth;
	public float SpaceBeetwen1;
	public float SpaceBeetwen2;
	public float Height;
	public float MaxVol;
	public float MinVol;
	
	public GUIContent DescriptionLabelContent;
	public GUIStyle DescriptionLabelStyle;
	public GUIStyle ValueLabelStyle;
	
	private GUIContent valueLabelContent = new GUIContent();
	private AudioSource musicSource;
	private Rect sliderRect;
	private Rect descriptionLabelRect;
	private Rect valueLabelRect;
	
	public void DisplayVolumeSlider () {
		GUI.Label(descriptionLabelRect, DescriptionLabelContent, DescriptionLabelStyle);
		musicSource.volume = (float) Math.Round(GUI.HorizontalSlider(sliderRect, musicSource.volume, MinVol, MaxVol), 1);
		valueLabelContent.text = (musicSource.volume).ToString();
		GUI.Label(valueLabelRect, valueLabelContent, ValueLabelStyle);
	}
	
	private void Awake () {
		musicSource = AudioSourceTransform.audio;
		
		float totalWidth = SliderWidth + SpaceBeetwen1 + SpaceBeetwen2;
		float labelX = GUIMatrixScript.OriginalWidth/2f - totalWidth/2f;
		float sliderX = labelX + SpaceBeetwen1;
		
		descriptionLabelRect = new Rect(labelX, LabelY, 0, Height);
		sliderRect = new Rect(sliderX, SliderY, SliderWidth, Height);
		valueLabelRect = new Rect(sliderX + SpaceBeetwen2 + SliderWidth, LabelY, 0, Height);
	}
}
