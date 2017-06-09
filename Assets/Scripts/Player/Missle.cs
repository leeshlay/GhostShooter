namespace TGK.Project
{
    using System.Collections;
    using System.Collections.Generic;
    using TGK.Project;
    using UnityEngine;

    namespace TGK.Project
    {
        public class Missle : MonoBehaviour
        {

            private float _Damage;

            public void Start()
            {
                Player playerObj = GameObject.FindObjectOfType(typeof(Player)) as Player;
                _Damage = playerObj.getDamage();
            }

            private void OnCollisionEnter(Collision other)
            {
                if (other.gameObject.CompareTag("Enemy"))
                {
                    GameObject enemy = other.gameObject;

                    var damageMessage = new Messages.DamageMissle(_Damage);

                    MessageDispatcher.Send(damageMessage, enemy);
                }
                if (!other.gameObject.CompareTag("Player"))
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
