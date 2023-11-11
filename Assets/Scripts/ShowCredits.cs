using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowCredits : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI textToChange;
	[SerializeField] private string credits;

	public void ChangeText()
	{
		textToChange.text = credits;
	}
}
