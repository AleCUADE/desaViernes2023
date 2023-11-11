using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	[SerializeField] private Image healthBarImage;

	[SerializeField] private MainCharacter mainCharacter;
	[SerializeField] private float updateSpeed;
	[SerializeField] private float minDiff = 0.003f;
	[SerializeField] private GameObject pauseOverlay;
	[SerializeField] private TMP_Text collectableCoinAmount;
	private bool _isPaused = false;
	public void UpdateLifeBar(int currentHealth)
	{
		var target = (float)currentHealth / mainCharacter.MaxHealth;
		StartCoroutine(UpdateHealthRoutine(target));
	}

	private IEnumerator UpdateHealthRoutine(float target)
	{
		int maxIterations = 2000;
		int currentIteration = 0;
	
		//waitTime ??= new WaitForSeconds(updateTime);
		var currentFill = healthBarImage.fillAmount;

		while (currentFill != target)
		{
			currentFill -= updateSpeed * Time.deltaTime;
			var diff = Mathf.Abs(currentFill - target);
			if (diff < minDiff)
			{
				currentFill = target;
			}
			healthBarImage.fillAmount = currentFill;
			currentIteration++;
			if (currentIteration >= maxIterations)
			{
				Debug.LogError("Se rompio");
				break;
			}
			yield return null;
		}
	}

	private void Start()
	{
		SubscribeToPlayerEvents();
	}

	private void SubscribeToPlayerEvents() 
	{
		mainCharacter.OnDamaged.AddListener(UpdateLifeBar);
		mainCharacter.OnCoinGet.AddListener(UpdateCoinText);
	}


	public void PauseGame(bool isPaused)
	{
		pauseOverlay.SetActive(isPaused);
		Time.timeScale = isPaused ? 0 : 1f;

		//if (isPaused)
		//{
		//	Time.timeScale = 0f;
		//}
		//else
		//{
		//	Time.timeScale = 1f;
		//}
	}

	public void UpdateCoinText(int coinAmount)
	{
		collectableCoinAmount.text = coinAmount.ToString();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			_isPaused = !_isPaused;
			PauseGame(_isPaused);
		}
	}
}
