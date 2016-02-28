using UnityEngine;
using Assets.Scripts.Health;

namespace Assets.Scripts
{
    class BaseAliveObject : BaseObject
    {
        protected BaseHealth Health;
        public float CurrentHealth { get { return Health.CurrentHealth; } }
        public bool IsAlive { get { return Health.CurrentHealth > 0; } }
        public float MaxHealth = 0;

        protected override void Start()
        {
            base.Start();
            Health = new BaseHealth(MaxHealth);
        }

        public bool ReceiveDamage(float damage)
        {
            Health.Damage(damage);
            return true;
        }
    }
}
