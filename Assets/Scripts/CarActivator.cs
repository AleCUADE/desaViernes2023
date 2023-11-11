
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarActivator : MonoBehaviour
{
    [SerializeField] private GameObject car1;
    [SerializeField] private GameObject car2;
    [SerializeField] private GameObject car3;
    [SerializeField] private float timeToActivate;

    private void Awake()
    {
        car1.SetActive(false);
        car2.SetActive(false);
        car3.SetActive(false);
    }

    private void Update()
    {
        timeToActivate -= Time.deltaTime;

        if (timeToActivate < 0)
        {
            car1.SetActive(true);
            car2.SetActive(true);
            car3.SetActive(true);
        }
    }

}
