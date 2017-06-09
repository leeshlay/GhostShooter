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
            public float Value;
            public HealthBonus(float value) {
                this.Value = value;
            }
        }

        public class DamageBonus
        {
            public float Value;
            public DamageBonus(float value)
            {
                this.Value = value;
            }
        }

        public class SpeedBonus
        {
            public float Value;
            public SpeedBonus(float value)
            {
                this.Value = value;
            }
        }
        #endregion Bonus
    }
}
