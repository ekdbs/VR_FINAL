using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // 플레이어 이동 속도
    [SerializeField] private float gravity = 10f; // 플레이어에게 적용되는 중력

    private CharacterController controller; // CharacterController 컴포넌트 참조
    private Vector3 mov; // 이동 벡터

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
