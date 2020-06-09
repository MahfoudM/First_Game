using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class third_person_movement : MonoBehaviourPun
{
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;

    public CharacterController controller;

    float turnSmoothVelocity;

    public Transform cam;
    private Transform mainCameraTransform = null;


    private void Start()
    {
        mainCameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 Movedir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                controller.Move(Movedir * speed * Time.deltaTime);


                Vector3 forward = mainCameraTransform.forward;
                Vector3 Right = mainCameraTransform.right;

                forward.y = 0f;
                Right.y = 0f;

                forward.Normalize();
                Right.Normalize();

                transform.rotation = Quaternion.LookRotation(Movedir);
            }
        }
    }
}
