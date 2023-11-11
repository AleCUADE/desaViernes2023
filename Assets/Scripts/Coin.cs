using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinsToGive;
	public int CoinsToGive => coinsToGive;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == 6 && collision.TryGetComponent<MainCharacter>(out var player))
		{
			player.GetCoin(this);
			Destroy(gameObject);
		}
	}
}
