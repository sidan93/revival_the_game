namespace Assets.Utilities
{
    public class Health
    {
        protected int maxHealth { private set; get; }
        public int currentHealth { private set; get; }

        public bool isAlive { get { return currentHealth > 0; } }

        public Health(int MaxHealth)
        {
            this.maxHealth = MaxHealth;
            currentHealth = MaxHealth;
        }

        public void Damage(int damage)
        {
            currentHealth -= damage;
        }
    }
}
