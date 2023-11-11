using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private string firstScene;

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
            MySceneManager.Instance.LoadNewScene(firstScene);
		}
    }
}
