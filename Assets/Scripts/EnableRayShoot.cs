
using UnityEngine;

public class EnableRayShoot : MonoBehaviour
{
    [SerializeField] private SelectPlanet sp;
    public static bool IsActive = false;

    public void CangeActive()
    {
        IsActive = !IsActive;
        Debug.Log(IsActive);
    }

  public void ActivateRay()
    {
        if (IsActive)
            sp.enabled = true;
        else
            sp.enabled = false;
    }
}