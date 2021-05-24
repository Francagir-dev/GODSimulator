using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Instantiateplanet : MonoBehaviour
{
    //RadiusX = Minor, RadiusZ = Major
    [SerializeField] private GameObject radiusXInputField, radiusZInput, speedInputField, moonRadiusInput;
    [SerializeField] private Text radiusXTxt, radiusZTxt, speedTxt, moonRadiusText;
    [SerializeField] private GameObject planetPrefab, moonPrefab;
    private GameObject planetInstantiate, moonInstantiate;
    private float speed, minAttrib, maxAttrib, xValue, zValue;
    private Transform rotateAroundSun;

    public void CreatePlanet()
    {
        if (radiusXTxt.text != String.Empty && radiusZTxt.text != String.Empty)
        {
            float.TryParse(radiusXTxt.text, out xValue);
            float.TryParse(radiusZTxt.text, out zValue);
            if (speedTxt.text == String.Empty)
                setUpSpeed(xValue);
            else
            {
                float.TryParse(speedTxt.text, out speed);
            }

            InstantiatePlanet();
        }
    }

    void setUpSpeed(float xValue)
    {
        if (xValue < 2f)
        {
            minAttrib = 7f;
            maxAttrib = 9f;
        }

        if (xValue < 5f && xValue > 2.0f)
        {
            minAttrib = 4f;
            maxAttrib = 6.9f;
        }

        if (xValue < 10f && xValue > 5.0f)
        {
            minAttrib = 2f;
            maxAttrib = 3.9f;
        }
        else
        {
            minAttrib = 0.5f;
            maxAttrib = 1.9f;
        }

        speed = Random.Range(minAttrib, maxAttrib);
    }

    public void InstantiatePlanet()
    {
        rotateAroundSun = GameObject.Find("Sun").transform;
        CoroutineManager.StopCoroutines();
        planetInstantiate = Instantiate(planetPrefab,
            rotateAroundSun.position + new Vector3(xValue, 0f, zValue), Quaternion.identity);
        planetInstantiate.GetComponent<GORotator>().a = xValue;
        planetInstantiate.GetComponent<GORotator>().b = zValue;
        planetInstantiate.GetComponent<GORotator>().rotation = GORotator.Rotator.RotateEllipse;
        planetInstantiate.GetComponent<GORotator>().speedRotation = (speed * 10) * Time.deltaTime;
        planetInstantiate.GetComponent<GORotator>().rotateAroundPlanetSun = GameObject.Find("Sun").transform;
        CoroutineManager.planets.Add(planetInstantiate);
        if (GameManager.CreateMoon)
        {
            CreateMoon();
        }

        CoroutineManager.ResumeCoroutines();
    }

    private void CreateMoon()
    {
        if (moonRadiusText.text != String.Empty)
        {
            CoroutineManager.StopCoroutines();
            float.TryParse(moonRadiusText.text, out xValue);
            moonInstantiate = Instantiate(moonPrefab,
                planetInstantiate.transform.position + new Vector3(xValue, 0f, xValue),
                Quaternion.identity);
            moonInstantiate.GetComponent<RotateAround>().planet = planetInstantiate.transform;
            moonInstantiate.GetComponent<RotateAround>().orbitDistance = xValue;
            CoroutineManager.moons.Add(moonInstantiate);
            moonRadiusText.text = string.Empty;
            moonRadiusInput.SetActive(false);
            CoroutineManager.ResumeCoroutines();
        }
    }
}