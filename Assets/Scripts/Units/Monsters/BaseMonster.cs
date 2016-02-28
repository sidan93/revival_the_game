using UnityEngine;
using Assets.Scripts.Weapon;
using Assets.Scripts.Utilities;
using Assets.Scripts.Units.Heroes;

namespace Assets.Scripts.Units.Monsters
{
    class BaseMonster : BaseUnit
    {
        public float DeathTime = 5;
        private LifeTimer deathTime;


        public delegate void onCollisionStayHero(BaseMonster monster, Hero hero);
        public event onCollisionStayHero eventCollistionStayHero;
        
        protected override void Start()
        {
            base.Start();
        }

        protected override void Update()
        {
            base.Update();

            if (!Health.IsAlive)
            {
                if (deathTime == null)
                {
                    deathTime = new LifeTimer(DeathTime);
                    animator.SetTrigger("Death");
                    rigidbody.isKinematic = true;
                    var box = this.gameObject.GetComponent<BoxCollider>();
                    box.isTrigger = true;
                }
                else if (!deathTime.isAlive)
                    Destroy(this.gameObject);
            }
        }

        void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject && collision.gameObject.tag == "Hero")
            {
                eventCollistionStayHero(this, collision.gameObject.GetComponent<Hero>());
            }
        }

        public override void MoveTo(Vector3 target)
        {
            base.MoveTo(target);
            if (animator)
            {
                animator.SetTrigger("Move");
            }
        }

        public float Attack(Vector3 target)
        {
            if (Weapon)
            {
                var attack = Weapon.Attack(target);
                if (attack != 0)
                {
                    if (animator)
                    {
                        animator.SetTrigger("Attack");
                    }
                }
                return attack;
            }
            return 0;
        }
    }
}
