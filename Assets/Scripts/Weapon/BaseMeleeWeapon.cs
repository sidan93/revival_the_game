using UnityEngine;

namespace Assets.Scripts.Weapon
{
    class BaseMeleeWeapon : BaseWeapon
    {
        private float lastAttackStart;
        public float AnimationTime;

        public bool IsAttack { get { return Time.time - lastAttackStart < AnimationTime; } }

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
