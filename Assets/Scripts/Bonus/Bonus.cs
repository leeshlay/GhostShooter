namespace TGK.Project
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Bonus : MonoBehaviour
    {
            
        private BonusType type;
        private int bonus = 0;

        // Use this for initialization
        void Start()
        {
            //select random type
            Array values = Enum.GetValues(typeof(BonusType));
            System.Random random = new System.Random();
            type  = (BonusType)values.GetValue(random.Next(values.Length));

            //select random bonus
            bonus = new System.Random().Next(10);
        }

        public BonusType getBonusType()
        {
            return type;
        }
    }
}
