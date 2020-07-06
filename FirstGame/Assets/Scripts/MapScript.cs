using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    public static bool MapIsOn = false;

    public GameObject MapUI;
    public GameObject GameplayUI;
    public GameObject Player;
    public GameObject CinemachineCamera;
    public MovementInput MovementScript;

    private void Update()
    {
       // updatePlayerPosition();

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (MapIsOn)
            {
                closeMap();   
            }
            else
            {
                openMap();
            }
        }
    }

    private void openMap()
    {
        MapUI.SetActive(true);
        GameplayUI.SetActive(false);
        MapIsOn = true;
       // Time.timeScale = 0f;
        CinemachineCamera.SetActive(false);
        MovementScript.DisableMovement = true;
        MovementScript.blockRotationPlayer = true;
    }

    private void closeMap()
    {
        MapUI.SetActive(false);
        GameplayUI.SetActive(true);
        MapIsOn = false;
       // Time.timeScale = 1f;
        CinemachineCamera.SetActive(true);
        MovementScript.DisableMovement = false;
        MovementScript.blockRotationPlayer = false;
    }
    /*
        void updatePlayerPosition()
        {
            PlayerIndicator.transform.position = Player.transform.position; // + some tuning
        }
     */
}
