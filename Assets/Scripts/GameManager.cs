using UnityEngine;


public class GameManager : MonoBehaviour
{
	public static GameManager Instance;//Field compartido entre instancias

	[SerializeField] private MainCharacter mainCharacter;
	[SerializeField] private string nextScene;

	private Goal _currentGoal;

	public void SetCurrentGoal(Goal goal)
	{
		_currentGoal = goal;
	}

	private void Awake()
	{
		if (Instance == null) 
		{
			Instance = this;//Pointer a si mismo
		}
		else
		{
			Destroy(gameObject);
		}
	}
	private void Start()
	{
		mainCharacter.OnDeath.AddListener(GameOver);
		mainCharacter.OnDamaged.AddListener(OnPlayerDamagedHandler);

	}

	private void GameOver()
	{
		//TODO: Pantalla de derrota, cambio de nivel, etc.
		Debug.Log("Perdi");
	}

	private void OnPlayerDamagedHandler(int playerHealth)
	{
		Debug.Log($"Le queda {playerHealth} vida al player");
	}

	private void Update()
	{
		if (_currentGoal == null || mainCharacter == null)
			return;

		if (_currentGoal.Arrived)
		{
			//Debug.Log("Gane");
			//SceneManager.LoadScene(2);
			MySceneManager.Instance.LoadNewScene(nextScene);
		}

		//if (mainCharacter.CurrentHealth <= 0)
		//{
		//	Debug.Log("Perdi");
		//} MAL (?
	}


	public void NextSceneChange(string value)
	{
		nextScene = value;
	}
}
