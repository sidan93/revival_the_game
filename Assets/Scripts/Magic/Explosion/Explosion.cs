using UnityEngine;
using Assets.Scripts.Units.Monsters;
using System.Collections.Generic;

namespace Assets.Scripts.Magic.Explosion
{
    class Explosion : BaseExplosion
    {
        public float explosionForce = 4;
        public float multiplier = 1;

        protected override void Start()
        {
            base.Start();

            var systems = GetComponentsInChildren<ParticleSystem>();
            foreach (ParticleSystem system in systems)
            {
                system.startSize *= multiplier;
                system.startSpeed *= multiplier;
                system.startLifetime *= Mathf.Lerp(multiplier, 1, 0.5f);
                system.Clear();
                system.Play();
            }

            float r = 10 * multiplier;
            var cols = Physics.OverlapSphere(transform.position, r);
            var rigidbodies = new List<Rigidbody>();
            foreach (var col in cols)
            {
                if (col.attachedRigidbody != null && !rigidbodies.Contains(col.attachedRigidbody))
                {
                    rigidbodies.Add(col.attachedRigidbody);
                }
            }
            foreach (var rb in rigidbodies)
            {
                rb.AddExplosionForce(explosionForce * multiplier, transform.position, r, 1 * multiplier, ForceMode.Impulse);
                if (rb.tag == BaseMonster.MonsterTag)
                    rb.GetComponent<BaseMonster>().ReceiveDamage(Damage);
            }
        }
    }
}
