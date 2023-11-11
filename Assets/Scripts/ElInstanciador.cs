using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ElInstanciador : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
	[SerializeField] private List<GameObject> prefabs;
	[SerializeField] private float timer;
	private float m_currentTimer;
	private int[] ints = { 1, 2, 3, 4, 4, 5, 65, 6, 54, 496, 49, 49, 4 };
	

	private void Start()
	{
		//While();
		For();
		Debug.Log(string.Format("El largo del array es {0}", ints.Length));
		Debug.Log(string.Format("Un numero random de una posicion random {0}", ints[Random.Range(0,ints.Length - 1)]));
	}

	private void For()
	{
		int randonNum = Random.Range(5, 10);
		for (int i = 0; i < randonNum; i++)
		{
			Vector3 spawnPosition = transform.position + new Vector3(i, 0, 0);
			GameObject prefabToInstantiate = prefabs[Random.Range(0, prefabs.Count)];
			Instantiate(prefabToInstantiate, spawnPosition, Quaternion.identity);
		}
	}

	private void Update()
	{
		m_currentTimer += Time.deltaTime;

		if (m_currentTimer >= timer) 
		{
			For();
			m_currentTimer = 0;
		}
	}
	private void While()
	{
		int elContador = 0;
		while (elContador < 5)
		{
			//0,1,2,3,4
			elContador++;
			Vector3 spawnPosition = transform.position + new Vector3(elContador, 0, 0);
			Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
		}
	}
}
