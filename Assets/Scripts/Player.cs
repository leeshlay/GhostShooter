using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float _Damage = 10;

    [SerializeField]
    private float _HP = 100;

    [SerializeField]
    private float _Speed = 2.5f;

    private Vector3 moveDirection = Vector3.zero;
    private float _Gravity = 10.0f;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded) {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= _Speed;
            // if (Input.GetButton("Jump"))
            //    moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= _Gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
