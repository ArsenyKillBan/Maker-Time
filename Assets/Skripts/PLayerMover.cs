using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerMover : MonoBehaviour
{

    [SerializeField] Animator animator;
    [SerializeField] float speed = 5f, jump = 5f;
    Vector3 velocity;
    float camerax = 0;
    CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        bool isrun = Input.GetKey(KeyCode.LeftShift);
        Vector3 moveDir = transform.right * x + transform.forward * z;
        float currentSpeed = speed * (isrun ? 2.5f : 1f);
        Vector3 finalMovement = moveDir * currentSpeed;
        float mousex = Input.GetAxis("Mouse X");
        float mousey = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.up * mousex * 3);
        camerax -= mousey * 2;
        camerax = Mathf.Clamp(camerax, -60, 60);
        Camera.main.transform.localRotation = Quaternion.Euler(camerax, 0, 0);

        if (characterController.isGrounded)
        {
            if (velocity.y < 0f)
            {
                velocity.y = -2f;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = Mathf.Sqrt(jump * -2f * -9.81f);
                animator.SetTrigger("Jump");
            }
        }
        velocity.y += -9.81f * Time.deltaTime;
        finalMovement.y = velocity.y;
        characterController.Move(finalMovement * Time.deltaTime);
        animator.SetBool("Isrun", isrun);
        float inputMagnitude = new Vector2(x, z).magnitude;
        animator.SetFloat("Speed", isrun && inputMagnitude > 0 ? 2.5f : inputMagnitude);
    }
}