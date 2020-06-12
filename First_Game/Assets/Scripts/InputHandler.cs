using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    float horizontal;
    float vertical;

    bool aimInput;
    bool sprintInput;
    bool crouchInput;
    bool reloadInput;
    bool switchInput;
    bool pivotInput;

    bool isInit;

    float delta;

    private void Start()
    {
        InitInGame();
    }

    private void InitInGame()
    {
        
    }

    public void Init()
    {
        
    }

    private void FixedUpdate()
    {
        if (!isInit)
            return;

        delta = Time.deltaTime;
    }

    private void Update()
    {
        if (!isInit)
            return;
    }
}
