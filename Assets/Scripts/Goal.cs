using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
	private bool _arrived;
	public bool Arrived => _arrived;

	private void Start()
	{
		GameManager.Instance.SetCurrentGoal(this);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == 6)
		{
			_arrived = true;
		}
	}
}
