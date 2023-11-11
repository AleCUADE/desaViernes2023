using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float timeToExplode;
    [SerializeField] private float explosionForce;
    [SerializeField] private float explosionRadius;
    [SerializeField] private LayerMask layerToExplode;
    private float _currentTime;

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= timeToExplode)
        {
            Explode();
        }
    }

    private void Explode()
    {
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, explosionRadius, layerToExplode);

        foreach (Collider2D col in colls)
        {
            Rigidbody2D objectRigidbody = col.attachedRigidbody;
            if (objectRigidbody != null) 
            {
                var dir = (col.transform.position - transform.position).normalized;
                objectRigidbody.AddForce(dir * explosionForce, ForceMode2D.Impulse);
            }
        }
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
