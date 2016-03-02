using UnityEngine;
using Assets.Scripts.Weapon.Bullet;

namespace Assets.Scripts.Weapon
{
    class BaseRangeWeapon : BaseWeapon
    {
        public BaseBullet Bullet;

        protected override void Start()
        {
            base.Start();
            lastAttackStart = Time.time;
        }

        /// <summary>
        /// Возвращает -1 как признак дальнобойной атаки
        /// </summary>
        public override float Attack(Vector3 Target)
        {
            if (Bullet == null)
                return 0;

            if (Time.time - lastAttackStart < AnimationTime)
                return 0;

            var ray = UnityEngine.Camera.main.ScreenPointToRay(Target);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var point = hit.point;
                point.y = Unit.GetComponent<Collider>().bounds.size.y / 3;

                Vector3 direction1 = (point - Unit.transform.position).normalized;
                var new_bullet = Object.Instantiate(Bullet, Unit.transform.position + direction1, Bullet.transform.rotation) as BaseBullet;
                new_bullet.Direction = (point - new_bullet.transform.position).normalized;
                new_bullet.LifeTime = Random.Range(5, 10);
                new_bullet.Damage = Damage;
            }
            lastAttackStart = Time.time;
            return -1;
        }
    }
}
