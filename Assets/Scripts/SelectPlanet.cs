using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class SelectPlanet : MonoBehaviour
{
    [Header("Shoot")] [SerializeField] private Camera camera;
    [SerializeField] private LayerMask layerHit;
    [SerializeField] private float rayDistance;

    [Header("UI")] [SerializeField] private GameObject textIndicative;
    [HideInInspector] public static GameObject PlanetToAddAMoon;
    [SerializeField] private Text radiusText;
    [SerializeField] private GameObject moonPrefab;
    public static GameObject moon;
    public GameObject dialog;
    private float xValue;
    private RaycastHit rayHit;

    private void OnEnable()
    {
        textIndicative.SetActive(true);
    }

    private void OnDisable()
    {
        if (textIndicative != null)
            textIndicative.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SelectGameObject();
    }

    private void SelectGameObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out rayHit, rayDistance, layerHit, QueryTriggerInteraction.Ignore))
            {
                dialog.SetActive(true); 
                PlanetToAddAMoon = rayHit.transform.gameObject;
            }
        }
    }

    public  void EnterRadius()
    {
        if (radiusText.text != String.Empty)
        {
            CoroutineManager.StopCoroutines();
            float.TryParse(radiusText.text, out xValue);
            moon = Instantiate(moonPrefab, PlanetToAddAMoon.transform.position + new Vector3(xValue, 0f, xValue),
                Quaternion.identity);
            moon.GetComponent<RotateAround>().planet = PlanetToAddAMoon.transform;
            moon.GetComponent<RotateAround>().orbitDistance = xValue;
            CoroutineManager.moons.Add(moon);
            radiusText.text = string.Empty;
            dialog.SetActive(false);
            CoroutineManager.ResumeCoroutines();
        }
    }
}