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

        private Animation animation;

        #endregion Inspector Variables

        private void Start()
        {
            animation = GetComponent<Animation> ();
            animation.Play("Idle1");
        }

        void Update()
        {
            CharacterController controller = GetComponent<CharacterController>();
            if (controller.isGrounded)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
               // moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                // if (Input.GetButton("Jump"))
                //    moveDirection.y = jumpSpeed;
            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);

            //animation for moving
            if(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
            {
                animation.Play("Walk");
            }
            else if(Input.GetKeyUp("w") || Input.GetKeyUp("a") || Input.GetKeyUp("s") || Input.GetKeyUp("d"))
            {
                animation.Play("Idle1");
            }
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

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Pick"))
            {
                GameObject bonus = other.gameObject;
                Debug.Log("bonus collected");
                bonus.SetActive(false);

                //generate bonus message
                var message = new Messages.HealthBonus()
                {
                    // Set data
                    Value = 10
                };
                Debug.Log("sending health message " + message.Value);
                //MessageDispatcher.Send(message, );

                Destroy(bonus);
                
            }
        }
        #endregion Unity Messages

    }
}
