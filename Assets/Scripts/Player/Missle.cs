using System.Collections;
using System.Collections.Generic;
using TGK.Project;
using UnityEngine;

namespace TGK.Project
{
    public class Missle : MonoBehaviour
    {

        private float damage;

        public void Start()
        {
            Player playerObj = GameObject.FindObjectOfType(typeof(Player)) as Player;
            damage = playerObj.getDamage();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                GameObject enemy = other.gameObject;

                var damageMessage = new Messages.DamageMissle(damage);

                //Debug.Log("Send Damge Message from missle");
                MessageDispatcher.Send(damageMessage, enemy);
            }
            if (!other.gameObject.CompareTag("Player")) {
                Destroy(gameObject);
            }
        }
    }
}
