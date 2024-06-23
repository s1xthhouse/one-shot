using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTest : MonoBehaviour
{
    public float speed = 5f;
    //public float rotationSpeed = 100f;

    private CharacterController characterController;
    private Animator animator;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0; // Убираем компоненту Y, чтобы движение было только по горизонтали
        cameraForward.Normalize(); // Нормализуем вектор

        Vector3 cameraRight = Camera.main.transform.right;

        Vector3 movement = (cameraForward * verticalInput + cameraRight * horizontalInput) * speed * Time.deltaTime;
        transform.Translate(movement);

        //if (direction.magnitude >= 0.1f)
        //{
        //    float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
         //   float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);
         //   transform.rotation = Quaternion.Euler(0f, angle, 0f);

         //   Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
          //  characterController.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);

            //animator.SetBool("IsWalking", true);
        //}
        //else
        //{
            //animator.SetBool("IsWalking", false);
        //}
    }
}