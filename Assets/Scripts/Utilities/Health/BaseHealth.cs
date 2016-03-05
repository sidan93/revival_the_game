namespace Assets.Scripts.Utilities.Health
{
    class BaseHealth
    {
        protected float MaxHealth { private set; get; }
        public float CurrentHealth { private set; get; }

        public bool IsAlive { get { return CurrentHealth > 0; } }

        public delegate void onEndedHealth();
        public event onEndedHealth eventEndedHealth;

        public BaseHealth(float MaxHealth)
        {
            this.MaxHealth = MaxHealth;
            CurrentHealth = MaxHealth;
        }

        public void Damage(float damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                if (eventEndedHealth != null)
                    eventEndedHealth();
            }
        }

        public void Increase(float health)
        {
            CurrentHealth += health;
            if (CurrentHealth > MaxHealth)
                CurrentHealth = MaxHealth;
        }
    }
}
