using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRot : MonoBehaviour
{
    [SerializeField] private float mouseSpeed = 8f; // ���콺 ����
    [SerializeField] private Transform playerBody; // �÷��̾� ������Ʈ�� ����

    private float mouseX = 0f; // �¿� ȸ����
    private float mouseY = 0f; // ���� ȸ����

    void Start()
    {
        if (playerBody == null)
        {
            playerBody = transform.parent; // �θ� ������Ʈ�� �ڵ����� �Ҵ�
        }

        Cursor.lockState = CursorLockMode.Locked; // Ŀ���� ȭ�� �߾ӿ� ����
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
