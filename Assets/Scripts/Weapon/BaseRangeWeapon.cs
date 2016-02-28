using UnityEngine;
using Assets.Scripts.Weapon.Bullet;

namespace Assets.Scripts.Weapon
{
    class BaseRangeWeapon : BaseWeapon
    {
        public BaseBullet Bullet;
        
        /// <summary>
        /// Возвращает -1 как признак дальнобойной атаки
        /// </summary>
        public override float Attack(Vector3 Target)
        {
            var ray = UnityEngine.Camera.main.ScreenPointToRay(Target);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var point = hit.point;
                point.y = Unit.transform.position.y;

                Vector3 direction1 = (point - Unit.transform.position).normalized * 2;
                var new_bullet = Object.Instantiate(Bullet, Unit.transform.position + direction1, Bullet.transform.rotation) as BaseBullet;
                new_bullet.Direction = (point - new_bullet.transform.position).normalized;
                new_bullet.LifeTime = Random.Range(1, 10);
                new_bullet.Damage = Damage;
            }
            return -1;
        }
    }
}
