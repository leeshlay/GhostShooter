﻿namespace TGK.Project
{
    using UnityEngine;

    public class Health : MonoBehaviour
    {
        #region Inspector Variables

        [SerializeField] private float _Health;
        [SerializeField] private BonusTimer _BonusTimer;
        #endregion Inspector Variables

        #region Private Methods

        private void Damage(Messages.Damage message)
        {
            // Decrease health by damage value
            _Health -= message.Value;

            // If the health reaches 0
            if (_Health <= 0.0f)
            {

                //play death animation
                var animation = gameObject.GetComponent<Animation>();
                animation.Play("Death1");

                // Notify player that we are dead
                MessageDispatcher.Send(new Messages.HealthDepleated(), gameObject);

            }
        }

        private void Bonus(Messages.HealthBonus message)
        {
            _Health += message.Value;
            _BonusTimer.AddBonusTimerText("Health Bonus");
        }

        #endregion Private Methods

        public float getHealth() { return _Health; }
    }
}