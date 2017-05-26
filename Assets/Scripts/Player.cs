namespace TGK.Project
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Player : MonoBehaviour
    {

        #region Inspector Variables
        [Tooltip("Radius for message sending")]
        [SerializeField]
        private float _Radius = 1.0f;
        [SerializeField]
        private float damage = 10;

        //[SerializeField]
        //private float HP = 100;

        [SerializeField]
        private float speed = 2.5f;

        private Vector3 moveDirection = Vector3.zero;
        private float gravity = 10.0f;

        #endregion Inspector Variables

        void Update()
        {
            CharacterController controller = GetComponent<CharacterController>();
            if (controller.isGrounded)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                // if (Input.GetButton("Jump"))
                //    moveDirection.y = jumpSpeed;
            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }

        //public float getHP() { return HP; }
        public float getDamage() { return damage; }

        #region Unity Messages

        private void OnDrawGizmos()
        {
            // Draw Action message send radius
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _Radius);
        }
        #endregion Unity Messages

        #region Messages
        private void OnDeath(Messages.HealthDepleated message)
        {
            // Destroy itself
            Debug.Log("Dieded :<");
        }
        #endregion Messages
    }
}
