using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private GameObject gameManager;
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");
       
    }

    private void OnCollisionEnter(Collision other)
    {
        gameManager.GetComponent<GameManager>().ActivateEnd();
        CoroutineManager.StopCoroutines();
        
    }
}