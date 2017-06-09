namespace TGK.Project
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class Player : MonoBehaviour
    {

        #region Inspector Variables
        [Tooltip("Radius for message sending")]
        [SerializeField]
        private float _Radius = 1.0f;
        [SerializeField]
        private float _Damage = 10.0f;

        [SerializeField]
        private float _Speed = 2.5f;

        [SerializeField]
        private GameVariables _GameVariables;

        [SerializeField]
        private BonusTimer _BonusTimer;

        private Vector3 _MoveDirection = Vector3.zero;
        private float _Gravity = 10.0f;

        private Animation _Animation;
        private CharacterController _Controller;

        private bool _IsDead = false;
        

        #endregion Inspector Variables


        #region Public Methods 
        public void Start()
        {
            _Animation = GetComponent<Animation> ();
            _Animation.Play("Idle1");
            _Controller = GetComponent<CharacterController>();
        }

        public void Update()
        {
            if (_IsDead)
            {
                _Controller.enabled = false;
                _Animation.Play("Death1");
                Invoke("Die", 2.4f);
            }
            else
            {
                if (_Controller.isGrounded)
                {
                    _MoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                    // moveDirection = transform.TransformDirection(moveDirection);
                    _MoveDirection *= _Speed;
                }
                _MoveDirection.y -= _Gravity * Time.deltaTime;
                _Controller.Move(_MoveDirection * Time.deltaTime);

                //animation for moving
                if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
                {
                    _Animation.Play("Walk");
                }
                else if (Input.GetKeyUp("w") || Input.GetKeyUp("a") || Input.GetKeyUp("s") || Input.GetKeyUp("d"))
                {
                    _Animation.Play("Idle1");
                }
            }
        }

        public float getDamage() { return _Damage; }
        #endregion
        
        #region Private Methods 

        private void Die()
        {
            _GameVariables._GameOver = true;
            gameObject.SetActive(false);
            SceneManager.LoadScene("Menu");
            Cursor.visible = true;
        }

        private void Death(Messages.HealthDepleated message)
        {
            _IsDead = true;
        }
        #endregion


        #region Unity Messages
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Pick"))
            {
                GameObject bonus = other.gameObject;
                bonus.SetActive(false);

                //generate bonus message
                other.gameObject.GetComponent<Bonus>().SendBonusMessage(gameObject);
            }
        }
        #endregion Unity Messages

        #region Bonus Messages

        private void DamageBonus(Messages.DamageBonus message)
        {
            _Damage += message.Value;
            float time = 5.0f;
            _BonusTimer.AddBonusTimerText("Damage Bonus");
            StartCoroutine(DisableDamageBonus(message.Value, time));
        }

        private void SpeedBonus(Messages.SpeedBonus message)
        {
            _Speed += message.Value;
            float time = 5.0f;
            _BonusTimer.AddBonusTimerText("Speed Bonus");
            StartCoroutine(DisableSpeedBonus(message.Value, time));
        }
     
        IEnumerator DisableDamageBonus(float value, float time)
        {
            yield return new WaitForSeconds(time);
            _Damage -= value;
        }

        IEnumerator DisableSpeedBonus(float value, float time)
        {
            yield return new WaitForSeconds(time);
            _Speed -= value;
        }

        #endregion Bonus Messages
    }
}
