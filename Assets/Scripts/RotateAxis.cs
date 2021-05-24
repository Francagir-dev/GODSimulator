using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAxis : MonoBehaviour
{
    public static float xSpeed = 50f;
    public static float ySpeed = 50f;
    public static float zSpeed = 50f;
    public  AxisRotation axis;
    public enum AxisRotation
    {
        X_Axis,
        Y_Axis,
        Z_Axis
    }
    // Start is called before the first frame update
    void Start()
    {
        axis = AxisRotation.Y_Axis;
        StartCoroutine(RotationAxis());

    }

   
    IEnumerator RotationAxis()
    {
        yield return null;
        while (true)
        {
            transform.localEulerAngles += new Vector3(0f, ySpeed, 0f) * Time.deltaTime;
            yield return null;
        }
    }

}
