using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float lerpVel;
    // Update is called once per frame
    void Update()
    {
		transform.position = Vector3.Lerp(transform.position, player.position, lerpVel * Time.deltaTime);

	}
}
