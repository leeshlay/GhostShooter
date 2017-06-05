namespace TGK.Project
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Bonus : MonoBehaviour
    {
        private BonusType type;
        private float bonus = 0.0f;
        private float radius = 120.0f;

        void Start()
        {
            //select random type
            Array values = Enum.GetValues(typeof(BonusType));
            System.Random random = new System.Random();
            type  = (BonusType)values.GetValue(random.Next(values.Length));

            //select random bonus
            bonus = new System.Random().Next(4) + 1;
        }

        public BonusType getBonusType()
        {
            return type;
        }

        public void SendBonusMessage(GameObject gameObject)
        {
            if(type.Equals(BonusType.Health))
            {
                // Find objects to notify
                //var objects = Utility.OverlapSphere(transform.position, radius);

                //Debug.Log("Health bonus");
                MessageDispatcher.Send(new Messages.HealthBonus(bonus), gameObject);
            }
            else if (type.Equals(BonusType.Damage))
            {
                //Debug.Log("Damage bonus");
                MessageDispatcher.Send(new Messages.DamageBonus(bonus), gameObject);
            }
            else if(type.Equals(BonusType.Speed))
            {
                //Debug.Log("Speed bonus");
                MessageDispatcher.Send(new Messages.SpeedBonus(bonus), gameObject);
            }
            Destroy(this);
        }
    }
}
