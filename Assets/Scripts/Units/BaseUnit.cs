﻿using UnityEngine;
using Assets.Scripts.Weapon;
using Assets.Scripts.Movement;
using Assets.Scripts.Utilities.Magic;

namespace Assets.Scripts.Units
{
    class BaseUnit : BaseAliveObject
    {
        protected BaseMovement Movement;
        public float MaxSpeed = 10;

        public BaseWeapon Weapon = null;
        protected Animator animator;

        protected MagicBox magics;

        protected override void Start()
        {
            base.Start();

            Movement = new BaseMovement(MaxSpeed);
            animator = this.gameObject.GetComponent<Animator>();
            magics = new MagicBox(this);
        }

        protected override void Update()
        {
            base.Update();
        }

        public virtual void MoveTo(Vector3 target)
        {
            if (rigidbody)
                rigidbody.MovePosition(Vector3.MoveTowards(transform.position, target, Movement.CurrentSpeed * Time.fixedDeltaTime));

            var rotation = (target - transform.position).normalized;
            if (!rotation.Equals(Vector3.zero))
            {
                var q = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotation), Time.fixedDeltaTime * 5);
                q.x = 0;
                q.z = 0;
                transform.rotation = q;
            }
        }
    }
}
