using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool CoroutinesAreStopped;
    public static bool DrawGizmos;
    public static bool CreateMoon = true;
    public static bool hasSelectedOptionMoon;
    public static bool activateUI;
    
    [Header("UI ELEMENTS")]
   [SerializeField] private GameObject end;

    public GameObject End
    {
        get => end;
        set => end = value;
    }


    private void Awake()
   {
       end = GameObject.Find("end");
       end.SetActive(false);
       
   }

    public void ActivateEnd()
    {
        end.SetActive(true);
    }


   public void ChangeDrawGizmos()
    {
        DrawGizmos = !DrawGizmos;
    }
   public void ChangeMoon()
   {
       CreateMoon = !CreateMoon;
   }


   public void ActivateUIPlanet()
   {
       activateUI = !activateUI;
   }




}
