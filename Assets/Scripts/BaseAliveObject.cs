using Assets.Scripts.Utilities.Health;
using Assets.Scripts.Utilities.Mana;

namespace Assets.Scripts
{
    class BaseAliveObject : BaseObject
    {
        protected BaseHealth Health;
        public float CurrentHealth { get { return Health.CurrentHealth; } }
        public bool IsAlive { get { return Health.CurrentHealth > 0; } }
        public float MaxHealth = 0;

        protected BaseMana Mana;
        public float MaxMana;
        public float CurrentMana { get { return Mana.CurrentMana; } }

        protected override void Start()
        {
            base.Start();
            Health = new BaseHealth(MaxHealth);
            Mana = new BaseMana(MaxMana);
        }

        public bool ReceiveDamage(float damage)
        {
            Health.Damage(damage);
            return true;
        }

        public bool IncreaseHealth(float health)
        {
            Health.Increase(health);
            return true;
        }

        public bool ReduceMana(float mana)
        {
            Mana.Reduce(mana);
            return true;
        }

        public bool IncreaseMana(float mana)
        {
            Mana.Increase(mana);
            return true;
        }
    }
}
