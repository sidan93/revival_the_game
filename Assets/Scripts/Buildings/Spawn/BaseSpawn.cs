using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Units.Heroes;
using Assets.Scripts.Units.Monsters;

namespace Assets.Scripts.Buildings.Spawn
{
    class BaseSpawn : BaseBuilding
    {
        public BaseMonster Monster = null;
        // TODO Удалить и сделать нормально через нахождения героя в радиусе
        public Hero Target = null;
        public int SpawnLimit = 2;
        public bool isSpawn = true;

        private List<BaseMonster> monsters;
        private float startTime;

        protected override void Start()
        {
            base.Start();
            monsters = new List<BaseMonster>();
            startTime = Time.time;
        }

        protected override void Update()
        {
            base.Update();

            if (Target)
            {
                foreach (var monster in monsters)
                {
                    if (monster.IsAlive)
                        monster.MoveTo(Target.transform.position);
                }
            }

            if (Monster && Time.time - startTime > 1 && monsters.Count < SpawnLimit && isSpawn)
            {
                startTime = Time.time;
                var monster = Instantiate(Monster, Monster.transform.position + new Vector3(0, 50, 0), Monster.transform.rotation) as BaseMonster;
                monster.MaxHealth = Random.Range(monster.MaxHealth - 100, monster.MaxHealth + 100);
                monster.eventCollistionStayHero += onCollisionStayHero;
                monsters.Add(monster);
            }
        }

        void onCollisionStayHero(BaseMonster monster, Hero hero)
        {
            var damage = monster.Attack(hero.transform.position);
            if (damage > 0)
            {
                hero.ReceiveDamage(damage);
            }
        }
    }
}
