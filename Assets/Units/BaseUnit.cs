using UnityEngine;
using System.Collections.Generic;
using Assets.Utilities;

namespace Assets.Units
{
    public class BaseUnit : MonoBehaviour
    {
        protected Health health;
        protected Attack attack;
        public float Speed;

        public bool isAlive { get { return health.isAlive; } }
        public int currentHealth { get { return health.currentHealth; } }
        public bool setDamage(int damage)
        {
            health.Damage(damage);
            return true;
        }
    }
}
