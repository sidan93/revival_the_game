﻿using Assets.Scripts.Units;
using UnityEngine;

namespace Assets.Scripts.Weapon
{
    class BaseWeapon: BaseObject
    {
        public BaseUnit Unit;

        public float CurrentDamage;
        protected float Damage { private set; get; }

        protected override void Start()
        {
            Damage = CurrentDamage;
            Debug.Log(Damage);
        }

        /// <summary>
        /// Возвращает количественный урон, если он был нанесен
        /// 0 - Если атака не была совершена
        /// -1 - Если атака была с дальнего растояния и урон надо расчитывать от патрона
        /// </summary>
        /// <param name="Target">Точка в которую был совершен урон</param>
        public virtual float Attack(Vector3 Target)
        {
            return Damage;
        }
    }
}
