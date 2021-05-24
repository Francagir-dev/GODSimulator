using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateAround : MonoBehaviour
{
    public Transform planet;
    public float orbitDistance = 2f;
    [SerializeField] private float orbitDegreeSec = 360f;

    private void Start()
    {
        EnableRayShoot.IsActive = false;
        if (GameManager.CoroutinesAreStopped)
        {
            CoroutineManager.ResumeCoroutines();
        }
    }

    private void LateUpdate()
    {
        Orbit();
    }

    public void Orbit()
    {
        if (!EnableRayShoot.IsActive)
        {
            if (planet != null)
            {
                transform.position =
                    planet.position + (transform.position - planet.position).normalized * orbitDistance;
                transform.RotateAround(planet.position, Vector3.up,
                    (orbitDegreeSec * orbitDistance * 2.1f) * Time.deltaTime);
            }
        }
    }
}