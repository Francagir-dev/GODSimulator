using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Serialization;

[ExecuteInEditMode]
public class GORotator : MonoBehaviour
{
    public enum Rotator
    {
        None,
        RotateAround,
        RotateEllipse
    }

    public enum AxisRotation
    {
        X_Axis,
        Y_Axis,
        Z_Axis
    }

    public Rotator rotation;
    [SerializeField] [Space] private bool isWorldSpace;
    public Transform rotateAroundPlanetSun;
    [SerializeField] private Vector3 rotateAroundOffset;
    public AxisRotation axis;

    public static float xSpeed = 50f;
    public static float ySpeed = 50f;
    public static float zSpeed = 50f;

    [SerializeField] private float speed = 50f;

    [SerializeField] [Range(0.01f, 1f)] [Space]
    private Vector3 _randomRotation;

    private Vector3 _toRotation;
    private float _averageSpeed;


    [Header("Ellipse")] public float a;
    public float b;
    [SerializeField] private float alpha;
    [SerializeField] private int x = 0, y = 0;
    [SerializeField] private Vector3 center;
    public float speedRotation;
    private float X = 0, Y = 0;
    [SerializeField] [HideInInspector] private bool isNone;
    [SerializeField] [HideInInspector] private bool isRandomRotation;
    [SerializeField] [HideInInspector] private bool isRotateAxis;

    [SerializeField] [HideInInspector] private bool isRotateAround;

    private void Awake()
    {
        rotateAroundPlanetSun = GameObject.Find("Sun").transform;
     
    }

    private void OnEnable()
    {
        Coroutines();
        rotation = Rotator.RotateEllipse;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!Application.isPlaying)
            return;


       
    }


    IEnumerator RotateAround()
    {
        yield return null;
        Vector3 convertedPosition = rotateAroundPlanetSun.InverseTransformPoint(transform.position);

        while (true)
        {
            if (!isWorldSpace)
            {
                Vector3 rotateAroundSpeeds = new Vector3(xSpeed, ySpeed, zSpeed);
                Vector3 offsetPosition = convertedPosition + rotateAroundOffset;
                Vector3 newPosition = Quaternion.Euler(rotateAroundSpeeds * Time.deltaTime) * offsetPosition;
                transform.position = rotateAroundPlanetSun.TransformPoint(newPosition);
            }
            else
            {
                switch (axis)
                {
                    case AxisRotation.X_Axis:
                        transform.RotateAround(rotateAroundPlanetSun.position, Vector3.right, Time.deltaTime * speed);
                        break;
                    case AxisRotation.Y_Axis:
                        transform.RotateAround(rotateAroundPlanetSun.position, Vector3.up, Time.deltaTime * speed);
                        break;
                    case AxisRotation.Z_Axis:
                        transform.RotateAround(rotateAroundPlanetSun.position, Vector3.forward, Time.deltaTime * speed);
                        break;
                }
            }

            yield return null;
        }
    }

    IEnumerator RotateEllipseAround()
    {
        while (true)
        {
            alpha += speedRotation;
            X = x + (a * Mathf.Cos(alpha * .005f));
            Y = y + (b * Mathf.Sin(alpha * .005f));
            gameObject.transform.position = rotateAroundPlanetSun.position + new Vector3(X, 0f, Y);
            yield return null;
        }
    }

    public void Coroutines()
    {
        switch (rotation)
        {
            case Rotator.None:
                break;
            case Rotator.RotateAround:
                StartCoroutine(RotateAround());
                break;
            case Rotator.RotateEllipse:
                StartCoroutine(RotateEllipseAround());
                break;
        }
    }
}