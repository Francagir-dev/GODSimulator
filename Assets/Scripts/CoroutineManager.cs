using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : MonoBehaviour
{
    private static GameObject[] planet;
    public static List<GameObject> planets = new List<GameObject>();
    public static List<GameObject> moons = new List<GameObject>();
    private GameObject[] moon;

    // Start is called before the first frame update
    void Start()
    {
        planet = GameObject.FindGameObjectsWithTag("planet");
        foreach (GameObject planetObject in planet)
        {
            planets.Add(planetObject);
        }

        moon = GameObject.FindGameObjectsWithTag("moon");
        foreach (GameObject moonObject in moon)
        {
            moons.Add(moonObject);
        }
    }


    public static void ResumeCoroutines()
    {
        foreach (GameObject go in planets)
        {
            
            go.GetComponent<GORotator>().Coroutines();
        }
    }

    public static void StopCoroutines()
    {
        foreach (GameObject go in planets)
        {
            go.GetComponent<GORotator>().StopAllCoroutines();
        }
    }
}