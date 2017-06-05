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
        private float damage = 10.0f;

        [SerializeField]
        private float speed = 2.5f;

        [SerializeField]
        private GameVariables _GameVariables;

        [SerializeField]
        private BonusTimer _BonusTimer;

        private Vector3 moveDirection = Vector3.zero;
        private float gravity = 10.0f;

        private Animation animation;
        private CharacterController controller;

        private bool isDead = false;
        

        #endregion Inspector Variables


        #region Public Methods 
        public void Start()
        {
            animation = GetComponent<Animation> ();
            animation.Play("Idle1");
            controller = GetComponent<CharacterController>();
        }

        public void Update()
        {
            if (isDead)
            {
                controller.enabled = false;
                //disable shooting
                animation.Play("Death1");
                Invoke("Die", 2.4f);
            }
            else
            {
                if (controller.isGrounded)
                {
                    moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                    // moveDirection = transform.TransformDirection(moveDirection);
                    moveDirection *= speed;
                }
                moveDirection.y -= gravity * Time.deltaTime;
                controller.Move(moveDirection * Time.deltaTime);

                //animation for moving
                if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
                {
                    animation.Play("Walk");
                }
                else if (Input.GetKeyUp("w") || Input.GetKeyUp("a") || Input.GetKeyUp("s") || Input.GetKeyUp("d"))
                {
                    animation.Play("Idle1");
                }
            }
        }

        public float getDamage() { return damage; }
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
            isDead = true;
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
            damage += message.Value;
            float time = 5.0f;
            //set timer
            _BonusTimer.AddBonusTimerText("Damage Bonus");
            StartCoroutine(DisableDamageBonus(message.Value, time));
        }

        private void SpeedBonus(Messages.SpeedBonus message)
        {
            speed += message.Value;
            float time = 5.0f;
            _BonusTimer.AddBonusTimerText("Speed Bonus");
            StartCoroutine(DisableSpeedBonus(message.Value, time));
        }
     
        IEnumerator DisableDamageBonus(float value, float time)
        {
            yield return new WaitForSeconds(time);

            damage -= value;
        }

        IEnumerator DisableSpeedBonus(float value, float time)
        {
            yield return new WaitForSeconds(time);
            speed -= value;
        }

        #endregion Bonus Messages
    }
}
