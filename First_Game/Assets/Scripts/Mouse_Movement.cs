using UnityEngine;

public class Mouse_Movement : MonoBehaviour
{
    public Transform playerBody;
    public float MouseSensitivity = 100f;
    float Xrotation = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;
        Xrotation -= mouseY;

        Xrotation = Mathf.Clamp(Xrotation, -90f, 90f);
        Xrotation = Mathf.Clamp(Xrotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(Xrotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
