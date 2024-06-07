using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRot : MonoBehaviour
{
    [SerializeField] private float mouseSpeed = 8f; // 마우스 감도
    [SerializeField] private Transform playerBody; // 플레이어 오브젝트의 참조

    private float mouseX = 0f; // 좌우 회전값
    private float mouseY = 0f; // 상하 회전값

    void Start()
    {
        if (playerBody == null)
        {
            playerBody = transform.parent; // 부모 오브젝트를 자동으로 할당
        }

        Cursor.lockState = CursorLockMode.Locked; // 커서를 화면 중앙에 고정
    }

    void Update()
    {
        HandleCameraRotation();
    }

    private void HandleCameraRotation()
    {
        mouseX += Input.GetAxis("Mouse X") * mouseSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * mouseSpeed;

        mouseY = Mathf.Clamp(mouseY, -50f, 30f);

        playerBody.localEulerAngles = new Vector3(0, mouseX, 0);
        transform.localEulerAngles = new Vector3(mouseY, 0, 0);
    }
}
