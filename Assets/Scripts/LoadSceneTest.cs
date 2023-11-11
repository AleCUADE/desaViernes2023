using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneTest : MonoBehaviour
{
    [SerializeField] private string sceneName;

    void Start()
    {
        SceneManager.LoadScene(sceneName,LoadSceneMode.Additive);
    }
}
