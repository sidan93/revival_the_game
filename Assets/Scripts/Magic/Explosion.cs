using Assets.Scripts.Units.Monsters;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;

namespace Assets.Scripts.Magic
{
    class Explosion : BaseMagic
    {
        public Explosion()
        {
            _magicName = "BaseExplosion";
        }


        public float explosionForce = 4;

        protected override void Start()
        {
            base.Start();

            float multiplier = GetComponent<ParticleSystemMultiplier>().multiplier;

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
                Debug.Log(Damage);
                if (rb.tag == BaseMonster.MonsterTag)
                    rb.GetComponent<BaseMonster>().ReceiveDamage(Damage);
            }
        }
    }
}
