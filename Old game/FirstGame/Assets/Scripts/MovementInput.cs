﻿using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class MovementInput : MonoBehaviour
{
    public float InputX;
    public float InputZ;
    public Vector3 desiredMoveDirection;
    public bool DisableMovement;
    public bool blockRotationPlayer;
    public float desiredRotationSpeed = 0.1f;
    public Animator anim;
    public float Speed;
    public float allowPlayerRotation;
    public Camera cam;
    public CharacterController controller;
    public bool isGrounded;
    public float gravity = -9;
    Vector3 velocity;
    public Transform groundCheck;
    public float groundCheckDistance = 0.4f;
    public LayerMask groundMask;
    public float JumpHeight = 2f;
    public float MoveSpeed = 0f;
    private bool Run;
    private bool Jump;

    public int secs2Wait = 2;
    public int[] totalSec = new int[3];

    [SerializeField]
    private Transform MinimapIcon;

    [SerializeField]
    private Transform PlayerMapIcon;

    private void Start()
    {
        cam = Camera.main;
        controller = this.GetComponent<CharacterController>();
        anim = this.GetComponent<Animator>();
        Run = false;
        print(SystemInfo.graphicsDeviceName);
    }

    private void Update()
    {
        InputMagnitude();

        checkShift();
        checkSpeed();
        //checkJump();

        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);
        /*
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            if (Jump && isGrounded)
            {
                velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.Play("Jump");
                }
            }
         */
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (!DisableMovement)
        {
            anim.SetFloat("InputMagnitude", Speed, 0.0f, Time.deltaTime);
            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        }
        else
        {
            anim.SetFloat("InputMagnitude", 0, 0.0f, Time.deltaTime);
        }
    }

    void TimerInvoke()
    {
        if (totalSec[0] < secs2Wait)
            totalSec[0]++;
        else
            CancelInvoke("TimerInvoke");
    }

    void PlayerMoveAndRotation()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        var camera = Camera.main;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        desiredMoveDirection = forward * InputZ + right * InputX;

        if (blockRotationPlayer == false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
        }
    }

    void InputMagnitude()
    {
        //Calculate Input Vectors
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        anim.SetFloat("InputZ", InputZ, 0.0f, Time.deltaTime * 2f);
        anim.SetFloat("InputX", InputX, 0.0f, Time.deltaTime * 2f);

        //Calculate the Input Magnitude
        Speed = new Vector2(InputX, InputZ).normalized.sqrMagnitude;


        //Physically move player
        if (Speed > allowPlayerRotation)
        {
            anim.SetFloat("InputMagnitude", Speed, 0.0f, Time.deltaTime);
            PlayerMoveAndRotation();
        }
        else if (Speed < allowPlayerRotation)
        {
            anim.SetFloat("InputMagnitude", Speed, 0.0f, Time.deltaTime);
        }
    }

    void checkSpeed()
    {
        if (Speed <= 1 && Speed >= 0.5 && !Run)
        {
            MoveSpeed = 2f;
        }
        else if (Speed >= 0 && Speed <= 0.2)
        {
            MoveSpeed = 0f;
        }
        else if (Speed <= 1 && Speed >= 0.5 && Run)
        {
            MoveSpeed = 4f;
        }
    }

    void checkShift()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Run = true;
        }
        else
        {
            Run = false;
        }
        anim.SetBool("Run", Run);
    }
    /*
    void checkJump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Jump = true;
            anim.SetTrigger("Jump");
        }
    }
    */

    void MinimapIconRotation()
    {
        MinimapIcon.eulerAngles = desiredMoveDirection;
    }

    void PlayIndicatorMovement()
    {
        PlayerMapIcon.eulerAngles = desiredMoveDirection;
    }
}