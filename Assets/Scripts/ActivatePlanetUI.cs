using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePlanetUI : MonoBehaviour
{
    [SerializeField] private GameObject planetUI;


    private void Update()
    {
        if (GameManager.activateUI)
        {
            planetUI.SetActive(true);
        }
        else
        {
            planetUI.SetActive(false);
        }
          
    }
}