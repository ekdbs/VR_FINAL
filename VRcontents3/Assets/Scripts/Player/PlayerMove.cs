using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // �÷��̾� �̵� �ӵ�
    [SerializeField] private float gravity = 10f; // �÷��̾�� ����Ǵ� �߷�

    private CharacterController controller; // CharacterController ������Ʈ ����
    private Vector3 mov; // �̵� ����

    void Start()
    {
        controller = GetComponent<CharacterController>();
        mov = Vector3.zero;
    }

    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (controller.isGrounded)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Debug.Log($"Input Horizontal: {moveX}, Input Vertical: {moveZ}");

            Vector3 move = transform.right * moveX + transform.forward * moveZ;
            mov = move * speed;
        }

        mov.y -= gravity * Time.deltaTime;

        Debug.Log($"Movement Vector: {mov}");

        controller.Move(mov * Time.deltaTime);
    }
}
