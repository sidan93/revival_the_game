using UnityEngine;

namespace Assets.Utilities
{
    public class Attack
    {
        public int damage { private set; get; }
        public float attackSpeed { private set; get; }
        private float lastAttack;

        public Attack(int damage, float attackSpeed)
        {
            this.damage = damage;
            this.attackSpeed = attackSpeed;
            lastAttack = Time.time;
        }

        public int MakeAttack()
        {
            if (Time.time - lastAttack < attackSpeed)
                return 0;

            lastAttack = Time.time;
            return damage;
        }
    }
}
