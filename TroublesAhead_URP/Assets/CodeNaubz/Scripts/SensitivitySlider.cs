using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SensitivitySlider : MonoBehaviour
{
	public Slider slider;
	public TextMeshProUGUI percentage;
	public Action OnSensitivityChange;

	void Start()
	{
		// stop if there is no key corresponding to this slider
		if (!PlayerPrefs.HasKey("sensitivity")) return;

		// initialize slider and text display at the correct value
		float value = PlayerPrefs.GetFloat("sensitivity");
		slider.value = value;
		percentage.text = Mathf.RoundToInt(value).ToString();

	}

	public void OnValueChanged()
	{
		/* function called when there is a change on the slider associated.
		   triggered by the slider element
		 */

		// save value
		PlayerPrefs.SetFloat("sensitivity", slider.value);

		// change sensitivity
		OnSensitivityChange?.Invoke();

		// change percentage text
		percentage.text = Mathf.RoundToInt(slider.value).ToString();
	}
}