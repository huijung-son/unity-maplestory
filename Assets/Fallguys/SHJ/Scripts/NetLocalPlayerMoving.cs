using Unity.Netcode;  // Netcode for GameObjects 사용 시
using UnityEngine;

public class NetLocalPlayerMoving : NetworkBehaviour
{
    [Header("카메라 오프셋")]
    public Vector3 cameraOffset = new Vector3(0f, 2f, -4f);

    private Camera mainCam;
    
    private float rotX = 0f;
    private float rotY = 0f;
    private float mouseSensitivity = 130f;

    private float moveSpeed = 5f;

    void Start()
    {
        if (!IsOwner) return;

        mainCam = Camera.main;
        if (mainCam == null)
        {
            Debug.LogError("MainCamera를 찾을 수 없습니다!");
            return;
        }

        Transform camT = mainCam.transform;
        camT.SetParent(transform);
        camT.localPosition = cameraOffset;
        camT.localRotation = Quaternion.identity;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rotX = transform.rotation.eulerAngles.x;
        rotY = camT.rotation.eulerAngles.y;
    }
    
    private void Update()
    {
        float axisH = Input.GetAxis("Horizontal");
        float axisV = Input.GetAxis("Vertical");
        PlayerMoving(axisH, axisV);
    }

    private void PlayerYaw(float _axisX)
    {
        float newRotX = rotX + (_axisX * mouseSensitivity);
        rotX = Mathf.Lerp(rotX, newRotX, Time.deltaTime);
        Vector3 rot = transform.rotation.eulerAngles;
        rot.y = rotX;
        transform.rotation = Quaternion.Euler(rot);
    }

    private void CameraPitch(float _axisY)
    {
        float newRotY = rotY - (_axisY * mouseSensitivity);
        rotY = Mathf.Lerp(rotY, newRotY, Time.deltaTime);
        Vector3 rot = mainCam.transform.rotation.eulerAngles;
        rot.x = rotY;
        mainCam.transform.rotation = Quaternion.Euler(rot);
    }

    private void PlayerMoving(float _axisH, float _axisV)
    {
        if (!IsOwner || mainCam == null) return;
        
        Vector3 moveH = mainCam.transform.right * _axisH;
        moveH.y = 0f;
        moveH.Normalize();
        Vector3 moveV = mainCam.transform.forward * _axisV;
        moveV.y = 0f;
        moveV.Normalize();

        Vector3 moveDir = (moveH + moveV).normalized;

        transform.position += (moveSpeed * Time.deltaTime * moveDir);
    }

    void LateUpdate()
    {
        if (!IsOwner || mainCam == null) return;
        
        float axisX = Input.GetAxis("Mouse X");
        float axisY = Input.GetAxis("Mouse Y");
        PlayerYaw(axisX);
        CameraPitch(axisY);
        // // 부드러운 따라가기 로직 원하면 Lerp 등 추가
        // Transform camT = mainCam.transform;
        // Vector3 desiredPos = transform.TransformPoint(cameraOffset);
        // camT.position = Vector3.Lerp(camT.position, desiredPos, Time.deltaTime * 10f);
        // camT.LookAt(transform.position + Vector3.up * 1.5f);  // 시선 높이 조정
    }
}
