using UnityEngine;
using Assets.Scripts.Utilities;
using Assets.Scripts.Movement;
using Assets.Scripts.Units.Monsters;
using Assets.Scripts.Buildings;

namespace Assets.Scripts.Weapon.Bullet
{
    class BaseBullet : BaseObject
    {
        public Vector3 Direction;

        public float Damage = 0;

        protected BaseMovement Movement;
        public int MaxSpeed = 10;

        protected LifeTimer LifeTimer;
        public float LifeTime = 0;

        protected override void Start()
        {
            base.Start();

            LifeTimer = new LifeTimer(LifeTime);
            Movement = new BaseMovement(MaxSpeed);
            rigidbody.AddForce(Direction * Movement.CurrentSpeed, ForceMode.VelocityChange);
        }

        protected override void Update()
        {
            base.Update();

            if (!LifeTimer.isAlive)
                Destroy(this.gameObject);
        }

        void OnCollisionStay(Collision collision)
        {

            if (collision.gameObject && collision.gameObject.tag == "Monster")
            {
                var monster = collision.gameObject.GetComponent<BaseMonster>();
                monster.ReceiveDamage(Damage);
            }
            if (collision.gameObject && collision.gameObject.tag == "Building")
            {
                var building = collision.gameObject.GetComponent<BaseBuilding>();
                building.ReceiveDamage(Damage);
            }

            if (collision.gameObject && LifeTime != 0)
                LifeTimer.Kill();
        }
    }
}
