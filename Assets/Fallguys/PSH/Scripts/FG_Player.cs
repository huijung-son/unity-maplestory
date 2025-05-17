using UnityEngine;

public class FG_Player : MonoBehaviour
{
    private Transform camTr = null;

    private float curRotX = 0f;
    private float mouseSensitivity = 5f;

    private CharacterController charController = null;
    private float moveSpeed = 10f;


    private void Awake()
    {
       
    }

    private void Start()
    {
        camTr = GetComponentInChildren<Camera>().transform;
        charController = GetComponent<CharacterController>();
        curRotX = transform.localEulerAngles.x;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        PlayerRotate(mouseX);
        CameraRotate(mouseY);

        float axisH = Input.GetAxis("Horizontal");
        float axisV = Input.GetAxis("Vertical");
        PlayerMoving(axisH, axisV);
        //Moving();
    }

    private void PlayerRotate(float _mouseX)
    {
        curRotX += _mouseX * mouseSensitivity;
        transform.rotation = Quaternion.Euler(0f, curRotX, 0f);
    }

    // LootAt Camera
    private void CameraRotate(float _mouseY)
    {
        Vector3 curRot = camTr.localEulerAngles;
        curRot.x -= _mouseY * mouseSensitivity;

        camTr.localRotation =
            Quaternion.AngleAxis(curRot.x, Vector3.right);
    }

    private void PlayerMoving(float _axisH, float _axisV)
    {
        Vector3 dir = (transform.forward * _axisV) + (transform.right * _axisH);

        dir.Normalize();
        charController.SimpleMove(
                      dir * moveSpeed);
    }

}