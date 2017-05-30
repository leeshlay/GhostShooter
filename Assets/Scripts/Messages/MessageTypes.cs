namespace TGK.Project
{
    using UnityEngine;

    namespace Messages
    {
        #region Health
        public class Damage
        {
            public float Value;
        }

        public class HealthDepleated { }
        #endregion Health

        #region Bonus
        public class HealthBonus
        {
            public int Value;
        }

        #endregion Bonus
    }
}
