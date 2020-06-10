using Photon.Pun;
using UnityEngine;

public class third_person_movement : NetworkBehaviour
{
    private const int V = 0;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;

    public CharacterController controller = null;

    private Vector2 previousInput; 

    float turnSmoothVelocity;

    public Transform cam;
    private Transform mainCameraTransform = null;

    [SerializeField]
    private Transform controllerTransform = null;

    public Transform player;

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
            //Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            //if (direction.magnitude >= 0.1f)
            //{
                //float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

               // float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

               // transform.rotation = Quaternion.Euler(0f, angle, 0f);

                //Vector3 Movedir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                //controller.Move(Movedir * speed * Time.deltaTime)
            //}

            var movement = new Vector3
            {
                x = Input.GetAxisRaw("Horizontal"),
                y = 0f,
                z = Input.GetAxisRaw("Vertical")
            }.normalized;

            Vector3 forward = mainCameraTransform.forward;
            Vector3 right = mainCameraTransform.right;

            Vector3 calculatedMovement = (forward * movement.z + right * movement.x).normalized;

            if (calculatedMovement != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(calculatedMovement);
            }

            controller.Move(calculatedMovement * speed * Time.deltaTime);
        }
    }

    private void TakeInput()
    {

    }
}
