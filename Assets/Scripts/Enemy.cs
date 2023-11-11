using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float checkFloorDistance;
    [SerializeField] private LayerMask floorLayerMask;

    private void Update()
    {
        MoveToOwnRight();
    }

    private void MoveToOwnRight()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        Raycast();
    }

    private void Raycast()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, -transform.up, checkFloorDistance, floorLayerMask);
        if (!raycastHit2D)
        {
            transform.right *= -1;
        }
    }
}
