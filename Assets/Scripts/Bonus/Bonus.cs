namespace TGK.Project
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Bonus : MonoBehaviour
    {
        private BonusType _Type;
        private float _Bonus = 0.0f;

        void Start()
        {
            //select random type
            Array values = Enum.GetValues(typeof(BonusType));
            System.Random random = new System.Random();
            _Type  = (BonusType)values.GetValue(random.Next(values.Length));

            //select random bonus
            _Bonus = new System.Random().Next(4) + 1;
        }

        public BonusType getBonusType()
        {
            return _Type;
        }

        public void SendBonusMessage(GameObject gameObject)
        {
            if(_Type.Equals(BonusType.Health))
            {
                MessageDispatcher.Send(new Messages.HealthBonus(_Bonus), gameObject);
            }
            else if (_Type.Equals(BonusType.Damage))
            {
                MessageDispatcher.Send(new Messages.DamageBonus(_Bonus), gameObject);
            }
            else if(_Type.Equals(BonusType.Speed))
            {
                MessageDispatcher.Send(new Messages.SpeedBonus(_Bonus), gameObject);
            }
            Destroy(this);
        }
    }
}
