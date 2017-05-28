namespace TGK.Project
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Enemy : MonoBehaviour
    {

        #region Inspector Variables
        [SerializeField] private float Radius = 1.0f;
        [SerializeField] private float Damage = 1.0f;
        [SerializeField] private float HP = 10;
        #endregion Inspector Variables

        public Animation animation;

        void Start()
        {
            animation = GetComponent<Animation>();
        }

        #region Unity Messages
        private void Update()
        {
            // Create Damage message
            var message = new Messages.Damage()
            {
                // Set data
                Value = Damage * Time.deltaTime
            };

            //Debug.Log("Enemy sends damage");

            // Find objects to notify
            var objects = Utility.OverlapSphere(transform.position, Radius);
            // Send to nearby objects
            MessageDispatcher.Send(message, objects);
        }

        private void OnDrawGizmos()
        {
            // Draw damage inflicting zone
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, Radius);
        }

        private void OnControllerColliderHit(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("Attack");
                animation.Play("Attack");
            }
        }

        /*private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("Walk");
                animation.CrossFade("Walk");
            }
        }*/

        #endregion Unity Messages

    }
}
