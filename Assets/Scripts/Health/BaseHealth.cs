using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Health
{
    class BaseHealth
    {
        protected float MaxHealth { private set; get; }
        public float CurrentHealth { private set; get; }

        public bool IsAlive { get { return CurrentHealth > 0; } }

        public BaseHealth(float MaxHealth)
        {
            this.MaxHealth = MaxHealth;
            CurrentHealth = MaxHealth;
        }

        public void Damage(float damage)
        {
            CurrentHealth -= damage;
        }
    }
}
