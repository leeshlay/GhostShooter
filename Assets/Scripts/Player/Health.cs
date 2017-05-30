namespace TGK.Project
{
    using UnityEngine;

    /// <summary>
    /// Handles damage receiving,
    /// informs _Receiver about death
    /// </summary>
    public class Health : MonoBehaviour
    {
        #region Inspector Variables
        // The component to send messages to
        [SerializeField] private GameObject _Receiver;
        [SerializeField] private float _Health;
        #endregion Inspector Variables

        #region Private Methods
        /// <summary>
        /// Reacts to Damage message
        /// </summary>
        private void Damage(Messages.Damage message)
        {
            // Decrease health by damage value
            _Health -= message.Value;
            //Debug.Log("Health decreased...");

            // If the health reaches 0
            if (_Health <= 0.0f)
            {
                // Notify listeners that we are dead
                MessageDispatcher.Send(new Messages.HealthDepleated(), _Receiver);
            }
        }

        private void Bonus(Messages.HealthBonus message)
        {
            Debug.Log(message.Value);
            _Health += message.Value;
        }

        #endregion Private Methods

        public float getHealth() { return _Health; }
    }
}