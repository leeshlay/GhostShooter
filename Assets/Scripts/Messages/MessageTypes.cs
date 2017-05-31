namespace TGK.Project
{
    using UnityEngine;

    namespace Messages
    {
        #region Damage
        public class Damage 
        {
            public float Value;
            public Damage(float value)
            {
                this.Value = value;
            }
        }

        public class HealthDepleated { }
        #endregion

        #region DamageMissle
        public class DamageMissle
        {
            public float Value;
            public DamageMissle(float value)
            {
                this.Value = value;
            }
        }
        #endregion

        #region Bonus
        public class HealthBonus
        {
            public int Value;
            public HealthBonus(int value) {
                this.Value = value;
            }
        }

        #endregion Bonus
    }
}
