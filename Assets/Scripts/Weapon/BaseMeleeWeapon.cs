using UnityEngine;

namespace Assets.Scripts.Weapon
{
    class BaseMeleeWeapon : BaseWeapon
    {

        protected override void Start()
        {
            base.Start();
            lastAttackStart = Time.time;
        }

        public override float Attack(Vector3 Target)
        {
            if (Time.time - lastAttackStart < AnimationTime)
                return 0;

            lastAttackStart = Time.time;
            return Damage;
        }
    }
}
