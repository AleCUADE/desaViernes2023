using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button playGameButton;
	[SerializeField] private Button CreditsButton;
	[SerializeField] private Button exitGameButton;
    [SerializeField] private Button ToMainMenuButton;
	[SerializeField] private Button sayHiButton;

	[SerializeField] private string firstScene;

    [SerializeField] private GameObject mainMenuCanvas;
	[SerializeField] private GameObject creditsCanvas;

    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private Toggle sayHiToggle;

	private void Awake()
	{
        playGameButton.onClick.AddListener(PlayGame);
        CreditsButton.onClick.AddListener(GoToCredits);
        exitGameButton.onClick.AddListener(ExitGame);
        ToMainMenuButton.onClick.AddListener(ToMainMenu);
        sayHiButton.onClick.AddListener(SayHiToUser);
        sayHiToggle.onValueChanged.AddListener(ActivateSayHiMenu);
        ToMainMenu();
        ActivateSayHiMenu(false);
	}

	private void PlayGame()
    {
        MySceneManager.Instance.LoadNewScene(firstScene);
    }

    private void GoToCredits()
    {
        creditsCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
    }

    private void ExitGame()
    {
        if (Application.isEditor)
        {
			EditorApplication.ExitPlaymode();
		}
        else
        {
			Application.Quit();
		}
	}

    private void ToMainMenu()
    {
		creditsCanvas.SetActive(false);
		mainMenuCanvas.SetActive(true);
	}

    private void SayHiToUser()
    {
        string username = nameInputField.text;
        Debug.Log($"Hi, {username}");
	}

    private void ActivateSayHiMenu(bool state)
    {
        sayHiButton.gameObject.SetActive(state);
        nameInputField.gameObject.SetActive(state);
    }
}
