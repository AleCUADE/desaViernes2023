using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
	private void Start()
	{
        DontDestroyOnLoad(gameObject);
	}

	void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
		{
            ExitGame();
		}
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
