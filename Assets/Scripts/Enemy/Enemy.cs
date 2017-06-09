namespace TGK.Project
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Enemy : MonoBehaviour
    {

        #region Inspector Variables
        [SerializeField] private float _Radius = 1.0f;
        [SerializeField] private float _Damage = 1.0f;
        [SerializeField] private float _HP = 10;
        [SerializeField] private GameVariables _GameVariables;
        #endregion Inspector Variables

        private Animation _Animation;

        #region Public Methods
        public void Start()
        {
            _Animation = GetComponent<Animation>();
        }

        private void Update()
        {
            // Create Damage message
            var message = new Messages.Damage(_Damage * Time.deltaTime);

            // Find objects to notify
            var objects = Utility.OverlapSphere(transform.position, _Radius);
            // Send to nearby objects
            MessageDispatcher.Send(message, objects);
        }
        #endregion

        #region Unity Messages

        private void handleDamageMissleMessage(Messages.DamageMissle message)
        {
            _HP -= message.Value;
            if (_HP <= 0) {
                _GameVariables._Score += 1;
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                _Animation.Play("Attack");
            }
        }

        #endregion Unity Messages

    }
}
